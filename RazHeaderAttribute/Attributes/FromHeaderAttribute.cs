﻿using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazHeaderAttribute.Bindings;

namespace RazHeaderAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public sealed class FromHeaderAttribute : ParameterBindingAttribute
    {
        private readonly string headerName;
        private const string emptyString = ""; // string.Empty is not a compile time constant :(

        public FromHeaderAttribute(string headerName = emptyString)
        {
            this.headerName = headerName;
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderBinding(parameter, this.headerName);
        }
    }
}

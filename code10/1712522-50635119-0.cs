    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    
    namespace Microsoft.AspNetCore.Routing
    {
        public class ConstraintHost : IRouteConstraint
        {
    
            public string _value { get; private set; }
            public ConstraintHost(string value)
            {
                _value = value;
            }
    
            public bool Match(HttpContext httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                string hostURL = httpContext.Request.Host.ToString();
                if (hostURL == _value)
                {
                    return true;
                }
                //}
                return false;
                //return hostURL.IndexOf(_value, StringComparison.OrdinalIgnoreCase) >= 0;
            }
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                throw new NotImplementedException();
            }
        }
        public class ConstraintHostRouteAttribute : RouteAttribute
        {
            public ConstraintHostRouteAttribute(string template, string sitePermitted)
                : base(template)
            {
                SitePermitted = sitePermitted;
            }
    
            public RouteValueDictionary Constraints
            {
                get
                {
                    var constraints = new RouteValueDictionary();
                    constraints.Add("host", new ConstraintHost(SitePermitted));
                    return constraints;
                }
            }
    
            public string SitePermitted
            {
                get;
                private set;
            }
        }
    } 

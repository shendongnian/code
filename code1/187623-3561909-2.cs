        public class EchoConstraint : IRouteConstraint
        {
            private IRepository rep;
            public EchoConstraint(IRepository r) { rep = r; }
        
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                return rep.GetCategory(message) == 0;
            }
        }
    .
    .
    .
                            new RouteValueDictionary 
                                {{"CategoryName", new EchoConstraint(myDataAccessRepo)}}
                               );

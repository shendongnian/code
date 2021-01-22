    public static class RouteDatax
    {
        public RouteData myValue()
        {
                RouteData RouteDatax = (RouteData)(HttpContext.Current.Items["RouteData"]);
                return RouteDatax;
        }
    } 

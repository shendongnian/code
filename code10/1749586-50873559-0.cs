    IHttpRouteData requestRouteData = controllerContext.Request.GetRouteData();
    IEnumerable<IHttpRouteData> subroutes = (IEnumerable<IHttpRouteData>)requestRouteData.Values["MS_SubRoutes"];
    IHttpRouteData routeData = subroutes.FirstOrDefault();
    if (routeData != null)
    {
        this.AdvertisementID = routeData.Values["advertisementID"].ToString();
        this.BrandID = int.Parse(routeData.Values["brandID"].ToString());
    }

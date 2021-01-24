    BasicGeoposition startLocation = new BasicGeoposition() {Latitude=47.643,Longitude=-122.131};
    
       // End at the city of Seattle, Washington.
       BasicGeoposition endLocation = new BasicGeoposition() {Latitude = 47.604,Longitude= -122.329};
    
       // Get the route between the points.
       MapRouteFinderResult routeResult =
             await MapRouteFinder.GetDrivingRouteAsync(
             new Geopoint(startLocation),
             new Geopoint(endLocation),
             MapRouteOptimization.Time,
             MapRouteRestrictions.None);

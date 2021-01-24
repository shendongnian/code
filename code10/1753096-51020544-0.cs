    foreach (var routes in document.Descendants("RoutePoints"))
    {
        foreach (var points in routes.Elements())
        {
            if (points.Attributes(i + "type").FirstOrDefault()?.Value == "RoutePoint")
            {
            }
            if (points.Attributes(i + "type").FirstOrDefault()?.Value == "RoutePointTakeOff")
            {
            }
            if (points.Attributes(i + "nil").FirstOrDefault()?.Value == "true")
            {
            }
            if (points.Attributes(i + "type").FirstOrDefault()?.Value == "RoutePointLanding")
            {
            }
        }
    }

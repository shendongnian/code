    var result = dbContext.StopTimes
        .Where(stopTime => stopTime.Id == 2560378)
        .SelectMany(stopTime => stopTime.Trip.Routes
             .Where(route => route.StartDate <= 20190122 && route.EndDate >= 20190122)
        (stopTime, route) => new
        {
            DepartureTime = stopTime.DepartureTime,
            TripHeadSign = stopTime.Trip.HeadSign,
            Route = new
            {
                ShortName = route.ShortName,
                LongName = route.LongName,
            },
            // or, if you don't want a separate Route Property:
            RouteShortName = route.ShortName,
            RouteLongName = route.LongName,
        })
        .OrderBy(item => item.DepartureTime);

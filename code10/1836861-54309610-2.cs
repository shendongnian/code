    var result = dbContext.StopTimes
        .Where(stopTime => stopTime.Id == 2560378) // keep only StopTimes with Id == ...
        .Join(dbContext.Trips,                     // Join with Trips
        stopTime => stopTime.TripId,               // from every StopTime take the TripId
        trip => trip.Id                            // from every Trip take the Id,
        (stopTime, trip) => new                    // keep only the properties I need
        {
            DepartureTime = stopTime.DepartureTime,
            TripHeadSign = trip.HeadSign
            TripId = trip.Id,                      // Id is used in the next join
        }
        // join this joinResult with the eligible routes:
        .Join(dbContext.Routes
              .Where(route => route.StartDate <= ... && route.EndDate >= ...)
        firstJoinResult => firstJoinResult.TripId,
        route => route.TripId,
        (firstJoinResult, route) =>  new
        {
            DepartureTime = firstJoinResult.DepartureTime,
            TripHeadSign = firstJoinResult.TripHeadSign,
            Route = new
            {
                ShortName = route.ShortName,
                LongName = route.LongName,
            },
        })
        .OrderBy(item => item.DepartureTime);
        }

    foreach (var origin in origns)
    {
        foreach (var destination in destinations)
        {
            tasks.Add(
                _routeService.GetRoute(origin, destination)
                    .ContinueWith(response =>
                    {
                        foreach (var item in response.Result)
                            routes.Add(item);
                    })
            );
        }
    }

    public async Task<IEnumerable<Route>> GetRoutes(IEnumerable<Coordinates> origins, IEnumerable<Coordinates> destinations)
    {
        var tasks = origins
            .SelectMany
            (
                o => destinations.Select
                ( 
                    d => _routeService.GetRoute(o, d) 
                )
            );
        await Task.WhenAll( tasks.ToArray() );
        return tasks.SelectMany( task => task.Result );
    }

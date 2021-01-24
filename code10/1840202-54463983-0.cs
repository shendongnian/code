    public List<NXRoute> GetAllNXRoutesWithoutDuplicates(List<NXRoute> list)
    {
        var nxRoutesWithSameSignals = list.GroupBy(x => x.DestinationSignal);
        return nxRoutesWithSameSignals.Select(group => new NXRoute
        {
            DestinationSignal = group.Key,
            Path = group.SelectMany(x => x.Path).ToList()
        }).ToList();
    }

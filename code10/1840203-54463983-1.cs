    public List<NXRoute> GetAllNXRoutesWithoutDuplicates(List<NXRoute> list)
    {
        var nxRoutesWithSameDestinationSignals = list.GroupBy(x => x.DestinationSignal);
        return nxRoutesWithSameDestinationSignals.Select(group => new NXRoute
        {
            DestinationSignal = group.Key,
            Path = group.SelectMany(x => x.Path).ToList()
        }).ToList();
    }

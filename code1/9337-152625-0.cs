    decimal maxWeight = Enumerable.Max(list, delegate(IThing thing) 
        { return thing.Weight; }
    );
    decimal minWeight = Enumerable.Min(list, delegate(IThing thing)
        { return thing.Weight; }
    );

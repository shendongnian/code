    Dictionary<string, Queue<BatteryPack>> TypeToPack = new Dictionary<string, Queue<BatteryPack>>();
    
    foreach(BatteryPack pack in BatteryPacks)
    {
        if(!TypeToPack.ContainsKey(pack.BatteryType))
            TypeToPack.Add(pack.BatteryType, new Queue<BatteryPack>());
    
        TypeToPack[pack.BatteryType].Enqueue(pack);
    }

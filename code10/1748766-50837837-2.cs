    var worldPopulation = new Dictionary<string, Dictionary<string, long>>();
    Dictionary<string, long> sample = new Dictionary<string, long>();
    sample.Add("1", 5);
    sample.Add("2", 6);
    sample.Add("3", 7);
    worldPopulation.Add("first", sample);
    sample = new Dictionary<string,long>();
    sample.Add("3", 9);
    sample.Add("2", 9);
    sample.Add("1", 9);
    worldPopulation.Add("second", sample);
        
    var worldPopulationSorted = new Dictionary<string, Dictionary<string, long>>();
        
    worldPopulation.OrderByDescending(dic => dic.Value.Values.Sum()).ToList().ForEach(x => worldPopulationSorted.Add(x.Key, x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value)));

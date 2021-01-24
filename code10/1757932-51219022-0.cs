    public static Dictionary<int, int> GetPriceDictionary()
    {
        var duration = ((int[])Enum.GetValues(typeof(Duration))).ToList();
        var price = ((int[])Enum.GetValues(typeof(Price))).ToList();
        return  duration.Zip(price, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
    } 

    while (true)
    {
        System.Threading.Thread.Sleep(1000);
        var key = new Random().Next(3).ToString();
        string value;
        lock (cache)
        {
            value = (string)cache.GetData(key);
            if (value == null)
            {
                value = key;
                cache.Add(key, value, CacheItemPriority.Normal, null,
                    new SlidingTime(TimeSpan.FromSeconds(5)));
            }
        }
        Console.WriteLine("{0} --> '{1}'", key, value);
    }

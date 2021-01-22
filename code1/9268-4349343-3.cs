    private IEnumerable<List<object>> getSample()
    {
        var random = new Random();
            
        for (int loop = 0; loop < 3000; loop++)
        {
            yield return new List<object> {"test", DateTime.Now.AddDays(random.NextDouble()*100 - 50), loop};
        }
    }

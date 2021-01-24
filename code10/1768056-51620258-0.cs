    [HttpGet]
    public IDictionary<string, int> GetMyEnum()
    {
        var collection = new Dictionary<string, int>();
        Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>().ToList()
                .ForEach(v =>
                {
                    collection.Add(v.ToString(), (int)v);
                });
        return collection;
    }

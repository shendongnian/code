    [HttpGet]
    public IDictionary<string, int> GetMyEnum()
    {
        return Enum.GetValues(typeof(MyEnum))
                .Cast<MyEnum>()
                .ToDictionary(t => t.ToString(), t => (int)t);;
    }

    public string MyProperty
    {
        get
        {
            return this.GetType().GetProperty("MyProperty").GetCustomAttributes(typeof(GuidAttribute), true).OfType<GuidAttribute>().First().Value;
        }
    }

    private MS[] products;
    public string ProductsList
    {
        get
        {
            return string.Join(", ", Array.ConvertAll(products, x => x.ToString()));
        }
        set
        {
            string[] names = value.Split(',');
            products = names.Select(name => (MS) Enum.Parse(typeof(MS), name.Trim()))
                            .ToArray();
        }
    }

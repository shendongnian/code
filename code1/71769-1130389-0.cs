    private MS[] products;
    public string ProductsList
    {
        get
        {
            return string.Join(", ", products.ConvertAll(x => x.ToString()));
        }
        set
        {
            string[] names = value.Split(',');
            products = names.Select(name => (MS) Enum.Parse(name.Trim()))
                            .ToArray();
        }
    }

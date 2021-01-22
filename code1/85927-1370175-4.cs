    private readonly IDictionary<Month, Double> productionRateForcast =
        new Dictionary<Month, Double>();
    public Double this[Month month]
    {
        get { return this.productionRateForcast[month]; }
        set { this.productionRateForcast[month] = value; }
    }

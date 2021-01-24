    public  enum PizzaStyle 
    {
        NewYork = 1,
        Chicago = 2,
        Greek = 4
    }
    public enum CrustType 
    {
        Thick = 1024,
        Thin = 2048,
        HandTossed = 4096
    }
    public enum CrustOption
    {
        Stuffed = 32768
    }
    public enum PizzaDoughOptions
    {
        NewYorkThin = PizzaStyle.NewYork + CrustType.Thin,
        NewYorkHandTossed = PizzaStyle.NewYork + CrustType.HandTossed,
        NewYorkThick = PizzaStyle.NewYork + CrustType.Thick,
        NewYorkThickStuffed = NewYorkThick + CrustOption.Stuffed,
        ChicagoThin = PizzaStyle.Chicago + CrustType.Thin,
        ChicagoHandTossed = PizzaStyle.Chicago + CrustType.HandTossed,
        ChicagoThick = PizzaStyle.Chicago + CrustType.Thick,
        ChicagoThickStuffed = ChicagoThick + CrustOption.Stuffed,
        Greek = PizzaStyle.Greek // only comes one way?
    }

    public interface ICountry
    {
        ICountryInfo Info { get; }
    }
    public interface ICountryInfo
    {
        int Population { get; set; }
        string Note { get; set; }
    }

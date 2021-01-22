    public interface ICountry
    {
        ICountryInfo Info { get; }
    }
    public interface ICountryInfo
    {
        int Population { get; }
        string Note { get; }
    }

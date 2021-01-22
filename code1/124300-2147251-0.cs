    private static RateInstrument(string ric, string tenor, string date)
    {
        ...
    }
    public static RateInstrument FromRicAndTenor(string ric, string tenor)
    {
        return new RateInstrument(ric, tenor, null);
    }
    public static RateInstrument FromRicAndDate(string ric, string date)
    {
        return new RateInstrument(ric, null, date);
    }

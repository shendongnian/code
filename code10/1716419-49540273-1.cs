    public class CoveragePremium
    {
        public string premiumAnnual { get; set; }
    }
    public class CoverageOption
    {
        public double premiumAnnual { get; set; }
    }
    public class Data
    {
        public CoverageOption[] coverageOptions { get; set; }
        public List<string> errorMessages { get; set; }
        public bool success { get; set; }
    }
    public class ResultObject
    {
        public Data data { get; set; }
    }
    static void Main(string[] args)
    {
        string getPremiumResult = "{\"data\":{\"coverageOptions\":[{\"premiumAnnual\":11257.9284 }],\"errorMessages\":[],\"success\":true}}";
        var result = JsonConvert.DeserializeObject<ResultObject>(getPremiumResult);
        IEnumerable<CoveragePremium> premiumResults = from value in result.data.coverageOptions
                                                          select new CoveragePremium
                                                          {
                                                              premiumAnnual = value.premiumAnnual.ToString(CultureInfo.InvariantCulture)
                                                          };
        Console.ReadKey();
    }

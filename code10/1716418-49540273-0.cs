    var premiumDetails = JsonConvert.DeserializeObject<ResultObject>(getPremiumResult);
    public class ResultObject
    {
        public List<CoveragePremium> coverageOptions {get;set;}
    }

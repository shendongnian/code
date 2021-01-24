    public class SiteResponse
    {
        public List<MasterServiceResponse> SiteData { get; set; }
    }
    private static void TestJson()
    {
        var jsonValue = "{\"SiteData\":[{\"SAPId\":\"I-UW-SRPR-ENB-I001\",\"SiteRFEIDate\":\"03-11-2014\",\"SiteRFSDate\":\"03-11-2014\",\"ID_OD\":\"ID\",\"ID_ODchangeDate\":\"04-11-2018\",\"NoofRRHBase\":\"0\",\"RRHBaseChangeEffectiveDate\":\"\",\"No_Of_Tenancy\":\"3\",\"TenancyChangeEffectiveDate\":\"03-11-2014\",\"SiteStatus\":\"Active\",\"SiteDropDate\":\"\"}]}";
        var siteResponse = JsonConvert.DeserializeObject<SiteResponse>(jsonValue);
        List<MasterServiceResponse> records = siteResponse.SiteData;
    }

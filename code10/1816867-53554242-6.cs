    public class SiteData
    {
        public string SAPId { get; set; }
        public string SiteRFEIDate { get; set; }
        public string SiteRFSDate { get; set; }
        public string ID_OD { get; set; }
        public string ID_ODchangeDate { get; set; }
        public string NoofRRHBase { get; set; }
        public string RRHBaseChangeEffectiveDate { get; set; }
        public string No_Of_Tenancy { get; set; }
        public string TenancyChangeEffectiveDate { get; set; }
        public string SiteStatus { get; set; }
        public string SiteDropDate { get; set; }
    }
    
    public class RootObject
    {
        public List<SiteData> SiteData { get; set; }
    }

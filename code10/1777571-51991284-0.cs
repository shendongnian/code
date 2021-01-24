     public class RootObject
    {
        public int ReturnCode { get; set; }
        public int CampaignId { get; set; }
        public int TotalSMSSent { get; set; }
        public int TotalSMSwithError { get; set; }
        public MSISDNwithErrorList MSISDNwithErrorList { get; set; }   //Chnage from List to Object
    }

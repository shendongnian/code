    [Serializable]
        public class PurchaseInsurance
        {
            [Required(CheckType.IsNotNullorEmpty)]
            public string PartnerBookingID
            {
                get;
                set;
            }
            [Required(CheckType.IsNotNullorEmpty)]
            public string Currency
            {
                get;
                set;
            }
            public string ReferringURL;
    
            [Required(CheckType.HasValue, CheckType.CheckMinRequirements)]
            public PurchaserInfo Purchaser
            {
                get;
                set;
            }
            [Required(CheckType.HasValue, CheckType.ElementsRequirements)]
            public InsuranceProduct[] Products
            {
                get;
                set;
            }
    ...
    }

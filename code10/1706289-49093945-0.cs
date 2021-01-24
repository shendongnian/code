        public class Creator
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CreatorType { get; set; }
            public int CreatorTargetId { get; set; }
        }
        public class RootObject
        {
            public int TargetId { get; set; }
            public object ProductType { get; set; }
            public int AssetId { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int AssetTypeId { get; set; }
            public Creator Creator { get; set; }
            public int IconImageAssetId { get; set; }
            public DateTime Created { get; set; }
            public DateTime Updated { get; set; }
            public object PriceInRobux { get; set; }
            public object PriceInTickets { get; set; }
            public int Sales { get; set; }
            public bool IsNew { get; set; }
            public bool IsForSale { get; set; }
            public bool IsPublicDomain { get; set; }
            public bool IsLimited { get; set; }
            public bool IsLimitedUnique { get; set; }
            public object Remaining { get; set; }
            public int MinimumMembershipLevel { get; set; }
            public int ContentRatingTypeId { get; set; }
        }
       

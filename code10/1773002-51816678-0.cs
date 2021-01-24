        public class CampaignCustomerMatch
        {
            [Key]
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int id { get; set; }
            public string VisitorExternalId { get; set; }
            public string Url { get; set; }
            public string ReffererUrl { get; set; }
            public string ActivityDate { get; set; }
        }

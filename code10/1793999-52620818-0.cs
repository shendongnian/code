    public class RootObject
    {
        public List<Result> results { get; set; }
    }
    
    [JsonConverter(typeof(JsonPathConverter))]
    public class Result
    {
    	[JsonProperty("phone.raw")]
        public string Phone { get; set; }
    	[JsonProperty("accounts_balance_ach.raw")]
        public decimal AccountsBalanceAch { get; set; }
    	[JsonProperty("accounts_balance_pending.raw")]
        public decimal AccountsBalancePending { get; set; }
    	[JsonProperty("email.raw")]
        public string Email { get; set; }
    	[JsonProperty("accounts_count.raw")]
        public decimal AccountsCount { get; set; }
    	[JsonProperty("id.raw")]
        public string Id { get; set; }
    	[JsonProperty("display_name.raw")]
        public string DisplayName { get; set; }
    	[JsonProperty("type.raw")]
        public string Type { get; set; }
    	[JsonProperty("advisor_email.raw")]
        public string AdvisorEmail { get; set; }
    	[JsonProperty("created_at.raw")]
        public string CreatedAt { get; set; }
    	[JsonProperty("source.raw")]
        public string Source { get; set; }
    	[JsonProperty("accounts_balance.raw")]
        public decimal AccountsBalance { get; set; }
    	[JsonProperty("accounts_donations.raw")]
        public decimal AccountsDonations { get; set; }
    	[JsonProperty("advisor_name.raw")]
        public string AdvisorName { get; set; }
    	[JsonProperty("_meta.score")]
        public decimal MetaScore { get; set; }
    }

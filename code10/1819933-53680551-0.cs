      public class Metadata
    {
    }
    public class Metadata2
    {
    }
    public class Plan
    {
        public string id { get; set; }
        public string @string { get; set; }
        public bool active { get; set; }
        public string aggregate_usage { get; set; }
        public int amount { get; set; }
        public string billing_scheme { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public bool livemode { get; set; }
        public Metadata2 metadata { get; set; }
        public string nickname { get; set; }
        public string product { get; set; }
        public string tiers { get; set; }
        public string tiers_mode { get; set; }
        public string transform_usage { get; set; }
        public string trial_period_days { get; set; }
        public string usage_type { get; set; }
    }
    public class Datum
    {
        public string id { get; set; }
        public string @string { get; set; }
        public int created { get; set; }
        public Metadata metadata { get; set; }
        public Plan plan { get; set; }
        public int quantity { get; set; }
        public string subscription { get; set; }
    }
    public class Items
    {
        public string @string { get; set; }
        public List<Datum> data { get; set; }
        public bool has_more { get; set; }
        public int total_count { get; set; }
        public string url { get; set; }
    }
    public class Metadata3
    {
    }
    public class Metadata4
    {
    }
    public class Plan2
    {
        public string id { get; set; }
        public string @string { get; set; }
        public bool active { get; set; }
        public string aggregate_usage { get; set; }
        public int amount { get; set; }
        public string billing_scheme { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public bool livemode { get; set; }
        public Metadata4 metadata { get; set; }
        public string nickname { get; set; }
        public string product { get; set; }
        public string tiers { get; set; }
        public string tiers_mode { get; set; }
        public string transform_usage { get; set; }
        public string trial_period_days { get; set; }
        public string usage_type { get; set; }
    }
    public class content
    {
        public string id { get; set; }
        public string @string { get; set; }
        public string application_fee_percent { get; set; }
        public string billing { get; set; }
        public int billing_cycle_anchor { get; set; }
        public bool cancel_at_period_end { get; set; }
        public string canceled_at { get; set; }
        public int created { get; set; }
        public int current_period_end { get; set; }
        public int current_period_start { get; set; }
        public string customer { get; set; }
        public string days_until_due { get; set; }
        public string default_source { get; set; }
        public string discount { get; set; }
        public string ended_at { get; set; }
        public Items items { get; set; }
        public bool livemode { get; set; }
        public Metadata3 metadata { get; set; }
        public Plan2 plan { get; set; }
        public int quantity { get; set; }
        public int start { get; set; }
        public string status { get; set; }
        public string tax_percent { get; set; }
        public string trial_end { get; set; }
        public string trial_start { get; set; }
    }
    public class Data
    {
        public content @object { get; set; }
    }
    public class Request
    {
        public string id { get; set; }
        public string idempotency_key { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string @string { get; set; }
        public string api_version { get; set; }
        public int created { get; set; }
        public Data data { get; set; }
        public bool livemode { get; set; }
        public int pending_webhooks { get; set; }
        public Request request { get; set; }
        public string type { get; set; }
    }

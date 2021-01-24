    public class UsageAndDemandResponse
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        [JsonProperty("UsageAndDemand", NullValueHandling = NullValueHandling.Ignore)]
        public List<MeterUsageDemand> MeterUsageDemand { get; set; }
    }

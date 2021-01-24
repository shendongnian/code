    public partial class GetListItemsResult
    {
        [JsonProperty("MailData")]
        public RegisteredMailData[] RegisteredMailData { get; set; }
        [JsonProperty("ShipmentData")]
        public SendRecieveShipmentData[] SendRecieveShipmentData { get; set; }
        [JsonProperty("ErrorDetail")]
        public ErrorDetail ErrorDetail { get; set; }
        [JsonProperty("Result")]
        public bool Result { get; set; }
    }

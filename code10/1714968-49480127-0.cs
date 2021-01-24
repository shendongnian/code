    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConnectedStatusEnum
    { 
        [EnumMember(Value = "connected")]
        ConnectedEnum = 1,
        [EnumMember(Value = "pending")]
        PendingEnum = 2,
        [EnumMember(Value = "notConnected")]
        NotConnectedEnum = 3
    }

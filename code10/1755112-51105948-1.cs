    [JsonConverter(typeof(StringEnumConverter))]
    public enum DateSince
    {
        [EnumMember(Value = "LAST_DAY")]
        LastDay,
        [EnumMember(Value = "LAST_WEEK")]
        LastWeek,
        [EnumMember(Value = "LAST_MONTH")]
        LastMonth,
    }

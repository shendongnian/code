    [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore )]
    [DefaultDateTime]
    public DateTime EndTime;
    public class DefaultDateTimeAttribute : DefaultValueAttribute
    {
        public DefaultDateTimeAttribute()
            : base( default( DateTime ) ) { }
        public DefaultDateTimeAttribute( string dateTime )
            : base( DateTime.Parse( dateTime ) ) { }
    }

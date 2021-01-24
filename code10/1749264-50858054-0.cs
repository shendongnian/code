    using System;
	using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Converters;
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }
	public class Welcome
	{
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }
        // Look Ma! No hands!
		[JsonProperty("Weekly Adjusted Time Series")]
	    [JsonConverter(typeof(WelcomeConverter))]
	    public IEnumerable<WeeklyAdjustedTime> WeeklyAdjustedTimeSeries  { get; set; }
	}
	public class WelcomeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
    	{
        	return (objectType == typeof(object));
    	}
		
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
        	throw new NotImplementedException("Not implemented yet");
    	}
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
        	if (reader.TokenType == JsonToken.Null)
        	{
        	    return Enumerable.Empty<WeeklyAdjustedTime>();
        	} 
            // first and only pass!
			return JObject.Load(reader).ToObject<Dictionary<string, JObject>>().Select(x => {
				var wat = x.Value.ToObject<WeeklyAdjustedTime>();		
				return new WeeklyAdjustedTime
				{
					Date = x.Key,
					Open = wat.Open,
					High = wat.High,
					Low = wat.Low,
					Close = wat.Close,
					AdjustedClose = wat.AdjustedClose,
					Volume = wat.Volume,
					DividendAmount = wat.DividendAmount
				};
			});
    	}
	}
    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }
        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }
        [JsonProperty("3. Last Refreshed")]
        public DateTimeOffset LastRefreshed { get; set; }
        [JsonProperty("4. Time Zone")]
        public string TimeZone { get; set; }
    }
    public class WeeklyAdjustedTime
    {
        public string Date { get; set; }
		
        [JsonProperty("1. open")]
        public string Open { get; set; }
        [JsonProperty("2. high")]
        public string High { get; set; }
        [JsonProperty("3. low")]
        public string Low { get; set; }
        [JsonProperty("4. close")]
        public string Close { get; set; }
		
		[JsonProperty("5. adjusted close")]
        public string AdjustedClose { get; set; }
        [JsonProperty("6. volume")]
        public string Volume { get; set; }
        [JsonProperty("7. dividend amount")]
        public string DividendAmount { get; set; }
    }

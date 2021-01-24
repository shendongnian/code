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
            },
        };
    }
    public class Welcome
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }
        // we save it for a second deserialize
        [JsonProperty("Weekly Adjusted Time Series")]
        private JObject JWeeklyAdjustedTimeSeries { get; set; }
		
        // this is the object as it should be
		public IEnumerable<WeeklyAdjustedTime> WeeklyAdjustedTimeSeries { get; set; }
		
        public static Welcome FromJson(string json)
		{
            // first pass
			var welcome = JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
            // second pass
			welcome.WeeklyAdjustedTimeSeries = welcome.JWeeklyAdjustedTimeSeries.ToObject<Dictionary<string, JObject>>().Select(x => {
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
			return welcome;
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

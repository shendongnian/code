    class Program
    {
        static void Main()
        {
            // read the JSON into variable
            string json = System.IO.File.ReadAllText("input.json");
            // Convert the JSON text into C# object
            var welcomes = Welcome.FromJson(json);
            foreach (var welcome in welcomes)
            {
                // Your logic
            }
        }
    }
    public partial class SubLevel
    {
        [JsonProperty("data_tagname")]
        public PurpleDataTagname DataTagname { get; set; }
        [JsonProperty("data_title")]
        public DataTitle DataTitle { get; set; }
        [JsonProperty("data_menuid")]
        public object DataMenuid { get; set; }
        [JsonProperty("data_parentid")]
        public object DataParentid { get; set; }
        [JsonProperty("data_cmsid")]
        public object DataCmsid { get; set; }
        [JsonProperty("data_enabled")]
        public object DataEnabled { get; set; }
        [JsonProperty("data_isparent")]
        public object DataIsparent { get; set; }
        [JsonProperty("subLevel")]
        public Welcome[] SubLevelSubLevel { get; set; }
    }
    public partial class Welcome
    {
        [JsonProperty("data_tagname")]
        public WelcomeDataTagname DataTagname { get; set; }
        [JsonProperty("data_title")]
        public string DataTitle { get; set; }
        [JsonProperty("data_menuid")]
        public string DataMenuid { get; set; }
        [JsonProperty("data_parentid")]
        public string DataParentid { get; set; }
        [JsonProperty("data_cmsid")]
        public string DataCmsid { get; set; }
        [JsonProperty("data_enabled")]
        public string DataEnabled { get; set; }
        [JsonProperty("data_isparent")]
        public string DataIsparent { get; set; }
        [JsonProperty("subLevel")]
        public SubLevel[] SubLevel { get; set; }
    }
    public enum PurpleDataTagname { Ul };
    public enum DataTitle { Empty };
    public enum WelcomeDataTagname { Li };
    public partial class Welcome
    {
        public static Welcome[] FromJson(string json) => JsonConvert.DeserializeObject<Welcome[]>(json, Converter.Settings);
    }
    static class PurpleDataTagnameExtensions
    {
        public static PurpleDataTagname? ValueForString(string str)
        {
            switch (str)
            {
                case "UL": return PurpleDataTagname.Ul;
                default: return null;
            }
        }
        public static PurpleDataTagname ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }
        public static void WriteJson(this PurpleDataTagname value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case PurpleDataTagname.Ul: serializer.Serialize(writer, "UL"); break;
            }
        }
    }
    static class DataTitleExtensions
    {
        public static DataTitle? ValueForString(string str)
        {
            switch (str)
            {
                case "": return DataTitle.Empty;
                default: return null;
            }
        }
        public static DataTitle ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }
        public static void WriteJson(this DataTitle value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DataTitle.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }
    static class WelcomeDataTagnameExtensions
    {
        public static WelcomeDataTagname? ValueForString(string str)
        {
            switch (str)
            {
                case "LI": return WelcomeDataTagname.Li;
                default: return null;
            }
        }
        public static WelcomeDataTagname ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }
        public static void WriteJson(this WelcomeDataTagname value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case WelcomeDataTagname.Li: serializer.Serialize(writer, "LI"); break;
            }
        }
    }
    public static class Serialize
    {
        public static string ToJson(this Welcome[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PurpleDataTagname) || t == typeof(DataTitle) || t == typeof(WelcomeDataTagname) || t == typeof(PurpleDataTagname?) || t == typeof(DataTitle?) || t == typeof(WelcomeDataTagname?);
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(PurpleDataTagname))
                return PurpleDataTagnameExtensions.ReadJson(reader, serializer);
            if (t == typeof(DataTitle))
                return DataTitleExtensions.ReadJson(reader, serializer);
            if (t == typeof(WelcomeDataTagname))
                return WelcomeDataTagnameExtensions.ReadJson(reader, serializer);
            if (t == typeof(PurpleDataTagname?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return PurpleDataTagnameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(DataTitle?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DataTitleExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(WelcomeDataTagname?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return WelcomeDataTagnameExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(PurpleDataTagname))
            {
                ((PurpleDataTagname)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DataTitle))
            {
                ((DataTitle)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(WelcomeDataTagname))
            {
                ((WelcomeDataTagname)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

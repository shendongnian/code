    public class NotificationsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<NotificationInfo>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);
            return array.Children<JObject>()
                        .SelectMany(jo => jo.Properties())
                        .Select(jp => new NotificationInfo
                        {
                            EventName = jp.Name,
                            TargetIntId = (int)jp.Value["TargetIntId"],
                            Digest = (bool)jp.Value["Digest"]
                        })
                        .ToList();
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

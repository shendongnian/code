    public class PlayListConverter : JsonConverter<Playlist> {
        public override Playlist ReadJson(JsonReader reader, Type objectType, Playlist existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var json = JObject.ReadFrom(reader);
            var sources = json["Sources"].ToObject<Dictionary<string, Source>>();
            var master = json["MasterSource"].Value<string>();
            var result = new Playlist() {
                Sources = sources,
                MasterSource = sources[master]
            };
            return result;
        }
        public override void WriteJson(JsonWriter writer, Playlist value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }

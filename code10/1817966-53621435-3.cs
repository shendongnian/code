    public class EventConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Event);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Event evt = new Event();
            JObject obj = JObject.Load(reader);
            if (obj["event_id"] != null)
            {
                // JSON format #1
                evt.EventId = (int)obj["event_id"];
                evt.EventName = (string)obj["event_name"];
                evt.StartDate = (DateTime)obj["start_date"];
                evt.EndDate = (DateTime)obj["end_date"];
                evt.Guests = obj.SelectToken("participants.guests").ToObject<List<Guest>>(serializer);
            }
            else if (obj["name"] != null)
            {
                // JSON format #2
                evt.EventName = (string)obj["name"];
                evt.StartDate = (DateTime)obj["from"];
                evt.EndDate = (DateTime)obj["to"];
                evt.Guests = obj["guests"].ToObject<List<Guest>>(serializer);
            }
            else
            {
                throw new JsonException("Unknown format for Event");
            }
            return evt;
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

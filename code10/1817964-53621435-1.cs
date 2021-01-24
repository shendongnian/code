    public class GuestConverter : JsonConverter<Guest>
    {
        public override Guest ReadJson(JsonReader reader, Type objectType, Guest existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Guest guest = new Guest();
            JObject obj = JObject.Load(reader);
            if (obj["guest_id"] != null)
            {
                // JSON format #1
                guest.GuestId = (string)obj["guest_id"];
                guest.FirstName = (string)obj["first_name"];
                guest.LastName = (string)obj["last_name"];
            }
            else if (obj["email"] != null)
            {
                // JSON format #2
                guest.FirstName = (string)obj["firstName"];
                guest.LastName = (string)obj["lastName"];
                guest.Email = (string)obj["email"];
            }
            else
            {
                throw new JsonException("Unknown format for Guest");
            }
            return guest;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, Guest value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

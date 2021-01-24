    /*
     * parse the response
     */
    ARINWhois WhoisResp = JsonConvert.DeserializeObject<ARINWhois>(response);
    /*
     *  custom converter
     */
    class SingleOrArrayConverter<T> : JsonConverter
    {
      public override bool CanConvert(Type objectType)
      {
        return (objectType == typeof(List<T>));
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.Array)
        {
          return token.ToObject<List<T>>();
        }
        return new List<T> { token.ToObject<T>() };
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
    /*
     * data models
     */
    public class ARINWhois
    {
      [JsonProperty("nets")]
      public ARINNets Network { get; set; }
    }
    public class ARINNets
    {
      [JsonProperty("net")]
      [JsonConverter(typeof(SingleOrArrayConverter<ARINNet>))]
      public List<ARINNet> Networks;
    }
    public class ARINNet
    {
      [JsonProperty("registrationDate")]
      public ARINregistrationDate RegistrationDate;
      [JsonProperty("orgRef")]
      public ARINorgRef Organization;
      [JsonProperty("customerRef")]
      public ARINcustomerRef Customer;
    }
    public class ARINregistrationDate
    {
      [JsonProperty("$")]
      public string date { get; set; } 
    }
    public class ARINorgRef
    {
      [JsonProperty("@name")]
      public string name { get; set; }
      [JsonProperty("@handle")]
      public string handle { get; set; }
    }
    public class ARINcustomerRef
    {
      [JsonProperty("@name")]
      public string name { get; set; }
      [JsonProperty("@handle")]
      public string handle { get; set; }
    }

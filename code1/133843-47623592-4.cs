    [AddINotifyPropertyChangedInterface]
    class Entity : IChangeTracking
    {
      public string UserName { get; set; }
      public string LastName { get; set; }
      public bool IsChanged { get; private set; }
        string hash;
      string GetHash()
      {
        if (hash == null)
          using (var md5 = MD5.Create())
          using (var stream = new MemoryStream())
          using (var writer = new StreamWriter(stream))
          {
            _JsonSerializer.Serialize(writer, this);
            var hash = md5.ComputeHash(stream);
            this.hash = Convert.ToBase64String(hash);
          }
        return hash;
      }
      string acceptedHash;
      public void AcceptChanges() => acceptedHash = GetHash();
      static readonly JsonSerializer _JsonSerializer = CreateSerializer();
      static JsonSerializer CreateSerializer()
      {
        var serializer = new JsonSerializer();
        serializer.Converters.Add(new EmptyStringConverter());
        return serializer;
      }
      class EmptyStringConverter : JsonConverter
      {
        public override bool CanConvert(Type objectType) 
          => objectType == typeof(string);
        public override object ReadJson(JsonReader reader,
          Type objectType,
          object existingValue,
          JsonSerializer serializer)
          => throw new NotSupportedException();
        public override void WriteJson(JsonWriter writer, 
          object value,
          JsonSerializer serializer)
        {
          if (value is string str && str.All(char.IsWhiteSpace))
            value = null;
          writer.WriteValue(value);
        }
        public override bool CanRead => false;  
      }   
    }

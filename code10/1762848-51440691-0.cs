    // Flag to disable this converter for one operation, allowing this class to be serialised with default logic before being edited.
    bool skipOverMe = false;
    // Does the object have the Referable attribute?
    public override bool CanConvert(Type objectType)
    {
        return objectType.HasAttribute<ReferableAttribute>();
    }
    // When serialising, put the hashcode into the Json object.
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        // Disable this converter for default serialisation, preventing the infinite loop.
        skipOverMe = true;
        JObject jObj = JObject.FromObject(value);   // First, get the JObject.
        // FromObject calls CanWrite, so the converter has now been re-enabled.
        jObj.Add("HashCode", value.GetHashCode());  // Then add a one-off hashcode field.
        jObj.WriteTo(writer);
    }
    // Worry about this later ...
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return objectType.HasAttribute<ReferableAttribute>();
    }
    // Property to automatically re-enable this converter once the default serialisation has been carried out.
    public override bool CanWrite
    {
        get
        {
            if(skipOverMe)
            {
                Debug.Log("Reenabling HashConverter.");
                skipOverMe = false;
                return false;
            }
            else
            {
                return true;
            }
        }
    }

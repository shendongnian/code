    class Vec2DictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Dictionary<Vector2Int, Collection>).IsAssignableFrom(objectType);
        }
    
        //Deserialize json to an Object
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //Debug.Log("De-serializing!");
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Load JArray from stream
                JArray jArray = JArray.Load(reader);
    
                //Where to re-create the json data into 
                Dictionary<Vector2Int, Collection> dict = new Dictionary<Vector2Int, Collection>();
    
                if (jArray == null || jArray.Count < 2)
                {
                    return dict;
                }
    
                //Do the loop faster with +=2
                for (int i = 0; i < jArray.Count; i += 2)
                {
                    //first item = key
                    string firstData = jArray[i + 0].ToString();
                    //second item = value
                    string secondData = jArray[i + 1].ToString();
    
                    //Create Vector2Int key data 
                    Vector2Int vect = JsonConvert.DeserializeObject<Vector2Int>(firstData);
    
                    //Create Collection value data
                    Collection values = JsonConvert.DeserializeObject<Collection>(secondData);
    
                    //Add both Key and Value to the Dictionary if key doesnt exit yet
                    if (!dict.ContainsKey(vect))
                        dict.Add(vect, values);
                }
                //Return the Dictionary result
                return dict;
            }
            return new Dictionary<Vector2Int, Collection>();
        }
    
        //SerializeObject to Json
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //Debug.Log("Serializing!");
            if (value is Dictionary<Vector2Int, Collection>)
            {
                //Get the Data to serialize
                Dictionary<Vector2Int, Collection> dict = (Dictionary<Vector2Int, Collection>)value;
    
                //Loop over the Dictionary array and write each one
                writer.WriteStartArray();
                foreach (KeyValuePair<Vector2Int, Collection> entry in dict)
                {
                    //Write Key (Vector) 
                    serializer.Serialize(writer, entry.Key);
                    //Write Value (Collection)
                    serializer.Serialize(writer, entry.Value);
                }
                writer.WriteEndArray();
                return;
            }
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }

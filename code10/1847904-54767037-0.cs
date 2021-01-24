    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Console.WriteLine("Before");
        var n = (Node)value;
        writer.WriteStartObject();
        SerializeReferencedNode(writer, serializer, "Left", n.Left);
        SerializeReferencedNode(writer, serializer, "Right", n.Right);
        writer.WritePropertyName("Value");
        writer.WriteValue(n.Data);
        writer.WriteEndObject();
        Console.WriteLine("After");
    }
    
    private static void SerializeReferencedNode(JsonWriter writer, JsonSerializer serializer, 
                                                string propName, Node node)
    {
        if (node != null)
        {
            writer.WritePropertyName(propName);
            serializer.Serialize(writer, node);
        }
    }

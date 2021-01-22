    using (var writer = new StringWriter())
    {
        using (var sw = new StreamWriter(stream))
        {
            sw.Write("{");
    
            foreach (var kvp in keysAndValues)
            {
                sw.Write("'{0}':", kvp.Key);
                ser.WriteObject(writer, kvp.Value);
            }
            sw.Write("}");
        }
    
        return writer.ToString();
    }

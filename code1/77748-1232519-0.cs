    using (var stream = new MemoryStream())
    {
        var sw = new StreamWriter(stream))
        sw.Write("{");
        foreach (var kvp in keysAndValues)
        {
            sw.Write("'{0}':", kvp.Key);
            sw.Flush();
            ser.WriteObject(stream, kvp.Value);
        }    
        sw.Write("}");            
        sw.Flush();
        stream.Position = 0;
    
        using (var streamReader = new StreamReader(stream))
        {
            return streamReader.ReadToEnd();
        }
    }

    public void LoadJson(string path, object targetObject)
    {
       using (var sw = new StreamReader(path))
       {
            using (var reader = new JsonTextReader(sw))
            {
                var traceWriter = new MemoryTraceWriter();
                var serializer = JsonHelpers.DefaultSerializer;
    
                serializer.TraceWriter = traceWriter;
                serializer.Populate(reader, targetObject);
    
                Console.WriteLine(traceWriter);
            }
        }
    }
    

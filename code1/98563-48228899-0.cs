    public static class BuildTimeStamp
        {
            public static string GetTimestamp()
            {
                var assembly = Assembly.GetEntryAssembly(); 
    
                var stream = assembly.GetManifestResourceStream("NamespaceGoesHere.BuildTimeStamp.txt");
    
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

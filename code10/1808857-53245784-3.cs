    public static class JsonHelper
    {
        public static string SerializeWithCustomIndenting(object obj)
        {
            using (StringWriter sw = new StringWriter())
            using (JsonWriter jw = new CustomJsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(jw, obj);
                return sw.ToString();
            }
        }
    } 

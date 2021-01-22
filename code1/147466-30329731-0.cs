    using System;
    using System.IO;
    using Newtonsoft.Json;
    class JsonUtil
    {
        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            using (var jsonReader = new JsonTextReader(stringReader))
            using (var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented })
            {
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }

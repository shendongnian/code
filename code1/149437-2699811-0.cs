        using Newtonsoft.Json;
        public static class Dumper{
            public static string ToPrettyString(this object value)
            {
                 return JsonConvert.SerializeObject(value, Formatting.Indented);
            }
        }

    public class HttpClientDefaults
    {
        public static MediaTypeFormatterCollection MediaTypeFormatters
        {
            get
            {
                var p = typeof(HttpContentExtensions).
                    GetProperty("DefaultMediaTypeFormatterCollection",
                        System.Reflection.BindingFlags.NonPublic | 
                        System.Reflection.BindingFlags.Static);
                return (MediaTypeFormatterCollection)p.GetValue(null, null);
            }
        }
    }

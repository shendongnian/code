      public static class Extensions {
    
            public static string FormatX(this string format, params KeyValuePair<string, object> []  values) {
                string res = format;
                foreach (KeyValuePair<string, object> kvp in values) {
                    res = res.Replace(string.Format("{0}", kvp.Key), kvp.Value.ToString());
                }
                return res;
            }
        
        }

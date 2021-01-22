    public static class Extensions
     {
            
            public static string RemovePrefix(this string o, string prefix)
            {
                if (prefix == null) return o;
                return !o.StartsWith(prefix) ? o : o.Remove(0, prefix.Length);
            }
            
            public static string RemoveSuffix(this string o, string suffix)
            {
                if(suffix == null) return o;
                return !o.EndsWith(suffix) ? o : o.Remove(o.Length - suffix.Length, suffix.Length);
            }
        
        }

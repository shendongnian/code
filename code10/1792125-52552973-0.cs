    public static string ToFormat12h(this DateTime dt)
        {
            return dt.ToString("yyyy/MM/dd, hh:mm:ss tt");
        }
    
        public static string ToFormat24h(this DateTime dt)
        {
            return dt.ToString("yyyy/MM/dd, HH:mm:ss");
        }

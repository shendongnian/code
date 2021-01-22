    public static class Extension
    {
        public static string NameOf(this object o)
        {
            return o.GetType().Name;
        }
    }

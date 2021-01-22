    public static class Object
    {
        static Regex r = new Regex(@"^\d*\.*\d$", RegexOptions.Compiled);
        public static bool IsNumber(this object obj)
        {
            return r.IsMatch(obj.ToString() && !(obj is string);
        }
    }

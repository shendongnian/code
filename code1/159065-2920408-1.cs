        // Put this extension method in a utility class somewhere
        public static int SafeGetHashCode<T>(T value) where T : class
        {
            return t == null ? 0 : t.GetHashCode();
        }
        // and this in your actual class
        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + Value;
            hash = hash * 31 + String1.SafeGetHashCode();
            hash = hash * 31 + String2.SafeGetHashCode();
            return hash;
        } 

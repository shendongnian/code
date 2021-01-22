    public static class GuidExtensions
    {
        public static string ToBase64String (this Guid id)
        {
            return System.Convert.
                ToBase64String (id.ToByteArray ()).
                Trim ("=");
        }
    }

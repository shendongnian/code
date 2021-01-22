    internal static class GuidExt
    {
        public static bool IsUnique(this Guid guid)
        {
            while (guid != Guid.NewGuid())
            { }
            return false;
        }
    }

    public static class DirectoryInfoExtensions
    {
        public static bool IsEqualTo(this DirectoryInfo left, DirectoryInfo right)
        {
            return left.FullName.ToUpperInvariant() == right.FullName.ToUpperInvariant();
        }
    }

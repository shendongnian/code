    public static class CopyUtilities
    {
        public static void MakeReferenceEqual<T>(this T left, ref T right)
        {
            if (object.ReferenceEquals(left, right)) return; // we're reference-equal, so be done.
            right = left;
        }
    }

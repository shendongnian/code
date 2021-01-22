    public static class Helpers
    {
        // Adjust this to use trimming, avoid nullity etc if you you want
        private static readonly Predicate<string> 
            NonBlankLinePredicate = x => x.Length != 0;
        public static List<string> TrimList(this List<string> list)
        {
            int start = list.FindIndex(NonBlankLinePredicate);
            int end = list.FindLastIndex(NonBlankLinePredicate);
            // Either start and end are both -1, or neither is
            if (start == -1)
            {
                return new List<string>();
            }
            return list.GetRange(start, end - start + 1);
        }
    }

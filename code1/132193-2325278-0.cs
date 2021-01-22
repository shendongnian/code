    public static class Helpers
    {
        public static List<string> TrimList(this List<string> list)
        {
            int start = list.FindIndex(x => x.Length != 0);
            int end = list.FindLastIndex(x => x.Length != 0);
            // Either start and end are both -1, or neither is
            if (start == -1)
            {
                return new List<string>();
            }
            return list.GetRange(start, end - start + 1);
        }
    }

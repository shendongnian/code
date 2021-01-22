    public static class EnumerableExtension
    {
        public static bool IsEquivalentTo(this IEnumerable first, IEnumerable second)
        {
            var secondList = second.Cast<object>().ToList();
            foreach (var item in first)
            {
                var index = secondList.FindIndex(item.Equals);
                if (index < 0)
                {
                    return false;
                }
                secondList.RemoveAt(index);
            }
            return secondList.Count == 0;
        }
        public static bool IsSubsetOf(this IEnumerable first, IEnumerable second)
        {
            var secondList = second.Cast<object>().ToList();
            foreach (var item in first)
            {
                var index = secondList.FindIndex(item.Equals);
                if (index < 0)
                {
                    return false;
                }
                secondList.RemoveAt(index);
            }
            return true;
        }
    }

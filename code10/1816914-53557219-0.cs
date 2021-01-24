    public static class BoundedSearch
    {
        /// <summary>Same as C++'s equal_range()</summary>
        public static Tuple<int, int> EqualRange<T>(IList<T> values, T target) where T : IComparable<T>
        {
            int lowerBound = LowerBound(values, target, 0, values.Count);
            int upperBound = UpperBound(values, target, lowerBound, values.Count);
            return new Tuple<int, int>(lowerBound, upperBound);
        }
        /// <summary>Same as C++'s lower_bound()</summary>
        public static int LowerBound<T>(IList<T> values, T target, int first, int last) where T : IComparable<T>
        {
            int left  = first;
            int right = last;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                var middle = values[mid];
                if (middle.CompareTo(target) < 0)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }
        /// <summary>Same as C++'s upper_bound()</summary>
        public static int UpperBound<T>(IList<T> values, T target, int first, int last) where T : IComparable<T>
        {
            int left = first;
            int right = last;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                var middle = values[mid];
                if (middle.CompareTo(target) > 0)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
		

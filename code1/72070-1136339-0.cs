    public static class Extensions
    {
        public static int IndexOfMaximumElement<T>(this IList<T> list) 
            where T : IComparable
        {
            if (list.Count == 0)
                return -1;
            
            if (list.Count == 1)
                return 0;
            int maxIndex = 0;
            T maxValue = list[0];
            for (int i = 1; i < list.Count; ++i)
            {
                T thisValue = list[i];
                if (thisValue.CompareTo(maxValue) > 0)
                {
                    maxValue = thisValue;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }

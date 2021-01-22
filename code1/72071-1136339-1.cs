    public static class Extensions
    {
        public static int IndexOfMaximumElement(this IList<int> list)
        {
            int size = list.Count;
            if (size < 2)
                return size - 1;
            int maxValue = list[0];
            int maxIndex = 0;
            for (int i = 1; i < size; ++i)
            {
                int thisValue = list[i];
                if (thisValue > maxValue)
                {
                    maxValue = thisValue;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

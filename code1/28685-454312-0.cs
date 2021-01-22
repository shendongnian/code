    public interface IRangeComparer<TRange, TValue>
    {
        /// <summary>
        /// Returns 0 if value is in the specified range;
        /// greater than 0 if value is above the range
        /// less than 0 if value is below the range
        int Compare(TRange range, TValue value);
    }
    
    
    /// <summary>
    /// See contract for Array.BinarySearch
    /// </summary>
    public static int BinarySearch<TRange, TValue>(IList<TRange> ranges,
                                                   TValue value,
                                                   IRangeComparer<TRange, TValue> comparer)
    {
        int min = 0;
        int max = ranges.Count-1;
        
        while (min <= max)
        {
            int mid = (min + max) / 2;
            int comparison = comparer.Compare(ranges[mid], value);
            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                min = mid+1;                
            }
            else if (comparison > 0)
            {
                max = mid-1;
            }
        }
        return ~min;
    }

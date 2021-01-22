    public class Range : IComparable<Range>
    {
          private readonly int bottom; // Add properties for these if you want
          private readonly int top;
          public Range(int bottom, int top)
          {
                 this.bottom = bottom;
                 this.top = top;
          }
          public int CompareTo(Range other)
          {
                 if (bottom < other.bottom && top < other.top)
                 {
                       return -1;
                 }
                 if (bottom > other.bottom && top > other.top)
                 {
                       return 1;
                 }
                 if (bottom == other.bottom && top == other.top)
                 {
                       return 0;
                 }
                 throw new ArgumentException("Incomparable values (overlapping)");
          }
          /// <summary>
          /// Returns 0 if value is in the specified range;
          /// less than 0 if value is above the range;
          /// greater than 0 if value is below the range.
          /// </summary>
          public int CompareTo(int value)
          {
                 if (value < bottom)
                 {
                       return 1;
                 }
                 if (value > top)
                 {
                       return -1;
                 }
                 return 0;
          }
    }
    // Just an existence search
    public static bool BinarySearch(IList<Range> ranges, int value)
    {
        int min = 0;
        int max = ranges.Count-1;
    
        while (min <= max)
        {
            int mid = (min + max) / 2;
            int comparison = ranges[mid].CompareTo(value);
            if (comparison == 0)
            {
                return true;
            }
            if (comparison < 0)
            {
                min = mid+1;
            }
            else if (comparison > 0)
            {
                max = mid-1;
            }
        }
        return false;
    }

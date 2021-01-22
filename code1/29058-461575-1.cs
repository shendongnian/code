    class Range
    {
       public int Start { get; set; }
       public int End { get; set; }
       static Dictionary<int, Range> values;
       static int[] arrToBinarySearchIn;
       public static void BuildRanges(IEnumerable<Range> ranges) { 
            values = new Dictionary<int, Range>();
            foreach (var item in ranges)
                values[item.Start] = item;
            arrToBinarySearchIn = values.Keys.ToArray();
            Array.Sort(arrToBinarySearchIn);
       }
       public static Range GetRange(int value)
       {
           int searchIndex = Array.BinarySearch(arrToBinarySearchIn, value);
           if (searchIndex < 0)
               searchIndex = ~searchIndex - 1;
           if (searchIndex < 0)
               return null;
           Range proposedRange = values[arrToBinarySearchIn[searchIndex]];
           if (proposedRange.End >= value)
               return proposedRange;
           return null;
       }
    }
    

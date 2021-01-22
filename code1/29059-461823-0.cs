    class Ranges
    {
        int[] starts = new[] { 1000, 22200 };
        int[] ends = new[] { 20400, 24444 };
    
        public int RangeIndex(int test)
        {
            int index = -1;
    
            if (test >= starts[0] && test <= ends[ends.Length - 1])
            {
                index = Array.BinarySearch(ends, test);
    
                if (index <= 0)
                {
                    index = ~index;
                    if (starts[index] > test) index = -1;
                }
            }
    
            return index;
        }
    }

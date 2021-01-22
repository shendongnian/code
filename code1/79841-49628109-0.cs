    namespace CustomExtensions
    {
        public static class Py
        {
            // make a range over [start..end) , where end is NOT included (exclusive)
            public static IEnumerable<int> RangeExcl(int start, int end)
            {
                return Enumerable.Range(start, end - start);
            }
            
            // make a range over [start..end] , where end IS included (inclusive)
            public static IEnumerable<int> RangeIncl(int start, int end)
            {
                return Enumerable.Range(start, end - start + 1);
            }
        } // end class Py
    }

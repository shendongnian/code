    public static class ArrayExtensions
    {
        public static int StartingIndex(this int[] x, int[] y)
        {
            var xIndex = 0;
            while(xIndex < x.length)
            {
                var found = xIndex;
                var yIndex = 0;
                while(yIndex < y.length && xIndex < x.length && x[xIndex] == y[yIndex])
                {
                    xIndex++;
                    yIndex++;
                }
    
                if(yIndex == y.length-1)
                {
                    return found;
                }
                
                xIndex = found + 1;
            }
    
            return -1;
        }
    }

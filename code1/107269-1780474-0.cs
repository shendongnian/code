    public static class ArrayExtensions
    {
        public static int StartingIndex(this int[] x, int[] y)
        {
            var found = -1;
            var xIndex = 0;
            var yIndex = 0;
    
            while(xIndex < x.length)
            {
                found = xIndex;
                while(yIndex < y.length && x[xIndex] == y[yIndex])
                {
                    xIndex++;
                    yIndex++;
                }
    
                if(yIndex == y.length-1)
                {
                    return found;
                }
                
                xIndex = found + 1;
                yIndex = 0;
                found = -1;
            }
    
            return -1;
        }
    }

    public static int IndexOfNthSB(string input,
                 char value, int startIndex, int nth)
            {
                if (nth < 1)
                    throw new NotSupportedException("Param 'nth' must be greater than 0!");
                var nResult = 0;
                for (int i = startIndex; i < input.Length; i++)
                {
                    if (input[i] == value)
                        nResult++;
                    if (nResult == nth)
                        return i;
                }
                return -1;
            }
 

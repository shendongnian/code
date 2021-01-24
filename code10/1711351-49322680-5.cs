    public static class StringExtensions
    {
        public unsafe static string RemoveUnsafe(this string source, string remove)
        {
            // convert to lower to enable case insensitive comparison
            string sourceLower = source.ToLower();
            // define working pointers
            int srcPos = 0;
            int srcLen = source.Length;
            int dstPos = 0;
            int rmvPos = 0;
            int rmvLen = remove.Length;
            // create char arrays to work with in the 'unsafe' code
            char[] destChar = new char[srcLen];
            fixed (char* srcPtr = source, srcLwrPtr = sourceLower, rmvPtr = remove, dstPtr = destChar)
            {
                // loop through each char in the source array
                while (srcPos < srcLen)
                {
                    // copy the char and move dest position on
                    *(dstPtr + dstPos) = *(srcPtr + srcPos);
                    dstPos++;
                    // compare source char to remove char
                    // note we're comparing against the sourceLower but copying from source so that
                    // a case insensitive remove preserves the rest of the string's original case
                    if (*(srcLwrPtr + srcPos) == *(rmvPtr + rmvPos))
                    {
                        rmvPos++;
                        if (rmvPos == rmvLen)
                        {
                            // if the whole string has been matched
                            // reverse dest position back by length of remove string
                            dstPos -= rmvPos;
                            rmvPos = 0;
                        }
                    }
                    else
                    {
                        rmvPos = 0;
                    }
                    // move to next char in source
                    srcPos++;
                }
            }
            // return the string
            return new string(destChar, 0, dstPos);
        }
        public static string RemoveSafe(this string source, string remove)
        {
            // convert to lower to enable case insensitive comparison
            string sourceLower = source.ToLower();
            string removeLower = remove.ToLower();
            // define working pointers
            int srcPos = 0;
            int srcLen = source.Length;
            int dstPos = 0;
            int rmvPos = 0;
            int rmvLen = remove.Length;
            // create char arrays to work with in the 'unsafe' code
            char[] destChar = new char[srcLen];
            // loop through each char in the source array
            while (srcPos < srcLen)
            {
                // copy the char and move dest position on
                destChar[dstPos] = source[srcPos];
                dstPos++;
                // compare source char to remove char
                // note we're comparing against the sourceLower but copying from source so that
                // a case insensitive remove preserves the rest of the string's original case
                if (sourceLower[srcPos] == removeLower[rmvPos])
                {
                    rmvPos++;
                    if (rmvPos == rmvLen)
                    {
                        // if the whole string has been matched
                        // reverse dest position back by length of remove string
                        dstPos -= rmvPos;
                        rmvPos = 0;
                    }
                }
                else
                {
                    rmvPos = 0;
                }
                // move to next char in source
                srcPos++;
            }
            // return the string
            return new string(destChar, 0, dstPos);
        }
    }

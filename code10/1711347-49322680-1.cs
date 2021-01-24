        public unsafe static string RemoveCaseInsensitive(this string source, string remove)
        {
            // convert to lower to enable case insensitive comparison
            string sourceLower = source.ToLower();
            // create char arrays to work with in the 'unsafe' code
            char[] sourceChar = source.ToCharArray();
            char[] sourceLowerChar = sourceLower.ToCharArray();
            char[] removeChar = remove.ToLower().ToCharArray(); // also to lower
            char[] destChar = new char[sourceChar.Length];
            // define working pointers
            int srcPos = 0;
            int srcLen = sourceChar.Length;
            int dstPos = 0;
            int rmvPos = 0;
            int rmvLen = removeChar.Length;
            // this creates memory pointers for each of the char arrays
            fixed (char* srcPtr = sourceChar, srcLwrPtr = sourceLowerChar, rmvPtr = removeChar, dstPtr = destChar)
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
            // copy the dest array to result array of the new length
            char[] resultChar = new char[dstPos];
            Buffer.BlockCopy(destChar, 0, resultChar, 0, dstPos);
            // return the string
            return new string(resultChar);
        }

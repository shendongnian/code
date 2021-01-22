        /// <summary>
        /// Matches a byte array to another byte array
        /// forwards or reverse
        /// </summary>
        /// <param name="a">byte array</param>
        /// <param name="offset">start offset</param>
        /// <param name="len">max length</param>
        /// <param name="b">byte array</param>
        /// <param name="direction">to move each iteration</param>
        /// <returns>true if all bytes match, otherwise false</returns>
        internal static bool Matches(ref byte[] a, int offset, int len, ref byte[] b, int direction = 1)
        {
            #region Only Matched from offset Within a and b, could not differ, e.g. if you wanted to mach in reverse for only part of a in some of b that would not work
            //if (direction == 0) throw new ArgumentException("direction");
            //for (; offset < len; offset += direction) if (a[offset] != b[offset]) return false;
            //return true;
            #endregion
            //Will match if b contains len of a and return a a index of positive value
            return IndexOfBytes(ref a, ref offset, len, ref b, len) != -1;
        }
    ///Here is the Implementation code
    
        /// <summary>
        /// Swaps two integers without using a temporary variable
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        internal static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        /// <summary>
        /// Swaps two bytes without using a temporary variable
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        internal static void Swap(ref byte a, ref byte b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        /// <summary>
        /// Can be used to find if a array starts, ends spot Matches or compltely contains a sub byte array
        /// Set checkLength to the amount of bytes from the needle you want to match, start at 0 for forward searches start at hayStack.Lenght -1 for reverse matches
        /// </summary>
        /// <param name="a">Needle</param>
        /// <param name="offset">Start in Haystack</param>
        /// <param name="len">Length of required match</param>
        /// <param name="b">Haystack</param>
        /// <param name="direction">Which way to move the iterator</param>
        /// <returns>Index if found, otherwise -1</returns>
        internal static int IndexOfBytes(ref byte[] needle, ref int offset, int checkLength, ref byte[] haystack, int direction = 1)
        {
            //If the direction is == 0 we would spin forever making no progress
            if (direction == 0) throw new ArgumentException("direction");
            //Cache the length of the needle and the haystack, setup the endIndex for a reverse search
            int needleLength = needle.Length, haystackLength = haystack.Length, endIndex = 0, workingOffset = offset;
            //Allocate a value for the endIndex and workingOffset
            //If we are going forward then the bound is the haystackLength
            if (direction >= 1) endIndex = haystackLength;
            #region [Optomization - Not Required]
            //{
                
                //I though this was required for partial matching but it seems it is not needed in this form
                //workingOffset = needleLength - checkLength;
            //}
            #endregion
            else Swap(ref workingOffset, ref endIndex);                
            #region [Optomization - Not Required]
            //{ 
                //Otherwise we are going in reverse and the endIndex is the needleLength - checkLength                   
                //I though the length had to be adjusted but it seems it is not needed in this form
                //endIndex = needleLength - checkLength;
            //}
            #endregion
            #region [Optomized to above]
            //Allocate a value for the endIndex
            //endIndex = direction >= 1 ? haystackLength : needleLength - checkLength,
            //Determine the workingOffset
            //workingOffset = offset > needleLength ? offset : needleLength;            
            //If we are doing in reverse swap the two
            //if (workingOffset > endIndex) Swap(ref workingOffset, ref endIndex);
            //Else we are going in forward direction do the offset is adjusted by the length of the check
            //else workingOffset -= checkLength;
            //Start at the checkIndex (workingOffset) every search attempt
            #endregion
            //Save the checkIndex (used after the for loop is done with it to determine if the match was checkLength long)
            int checkIndex = workingOffset;
            #region [For Loop Version]
            ///Optomized with while (single op)
            ///for (int checkIndex = workingOffset; checkIndex < endIndex; offset += direction, checkIndex = workingOffset)
                ///{
                    ///Start at the checkIndex
                    /// While the checkIndex < checkLength move forward
                    /// If NOT (the needle at the checkIndex matched the haystack at the offset + checkIndex) BREAK ELSE we have a match continue the search                
                    /// for (; checkIndex < checkLength; ++checkIndex) if (needle[checkIndex] != haystack[offset + checkIndex]) break; else continue;
                    /// If the match was the length of the check
                    /// if (checkIndex == checkLength) return offset; //We are done matching
                ///}
            #endregion
            //While the checkIndex < endIndex
            while (checkIndex < endIndex)
            {
                for (; checkIndex < checkLength; ++checkIndex) if (needle[checkIndex] != haystack[offset + checkIndex]) break; else continue;
                //If the match was the length of the check
                if (checkIndex == checkLength) return offset; //We are done matching
                //Move the offset by the direction, reset the checkIndex to the workingOffset
                offset += direction; checkIndex = workingOffset;                
            }
            //We did not have a match with the given options
            return -1;
        }

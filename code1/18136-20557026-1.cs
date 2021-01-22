        static void Main(string[] args)
        {
            //                                                         1   1  1  1  1  1  1  1  1  1  2   2   2
            //                           0  1  2  3  4  5  6  7  8  9  0   1  2  3  4  5  6  7  8  9  0   1   2  3  4  5  6  7  8  9
            byte[] buffer = new byte[] { 1, 0, 2, 3, 4, 5, 6, 7, 8, 9, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 5, 5, 0, 5, 5, 1, 2 };
            byte[] beginPattern = new byte[] { 1, 0, 2 };
            byte[] middlePattern = new byte[] { 8, 9, 10 };
            byte[] endPattern = new byte[] { 9, 10, 11 };
            byte[] wholePattern = new byte[] { 1, 0, 2, 3, 4, 5, 6, 7, 8, 9, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            byte[] noMatchPattern = new byte[] { 7, 7, 7 };
            int beginIndex = ByteArrayPatternIndex(buffer, beginPattern);
            int middleIndex = ByteArrayPatternIndex(buffer, middlePattern);
            int endIndex = ByteArrayPatternIndex(buffer, endPattern);
            int wholeIndex = ByteArrayPatternIndex(buffer, wholePattern);
            int noMatchIndex = ByteArrayPatternIndex(buffer, noMatchPattern);
        }
        /// <summary>
        /// Returns the index of the first occurrence of a byte array within another byte array
        /// </summary>
        /// <param name="buffer">The byte array to be searched</param>
        /// <param name="pattern">The byte array that contains the pattern to be found</param>
        /// <returns>If buffer contains pattern then the index of the first occurrence of pattern within buffer; otherwise, -1</returns>
        public static int ByteArrayPatternIndex(byte[] buffer, byte[] pattern)
        {
            if (buffer != null && pattern != null && pattern.Length <= buffer.Length)
            {
                int resumeIndex;
                for (int i = 0; i <= buffer.Length - pattern.Length; i++)
                {
                    if (buffer[i] == pattern[0]) // Current byte equals first byte of pattern
                    {
                        resumeIndex = 0;
                        for (int x = 1; x < pattern.Length; x++)
                        {
                            if (buffer[i + x] == pattern[x])
                            {
                                if (x == pattern.Length - 1)  // Matched the entire pattern
                                    return i;
                                else if (resumeIndex == 0 && buffer[i + x] == pattern[0])  // The current byte equals the first byte of the pattern so start here on the next outer loop iteration
                                    resumeIndex = i + x;
                            }
                            else
                            {
                                if (resumeIndex > 0)
                                    i = resumeIndex - 1;  // The outer loop iterator will increment so subtract one
                                else if (x > 1)
                                    i += (x - 1);  // Advance the outer loop variable since we already checked these bytes
                                break;
                            }
                        }
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Returns the indexes of each occurrence of a byte array within another byte array
        /// </summary>
        /// <param name="buffer">The byte array to be searched</param>
        /// <param name="pattern">The byte array that contains the pattern to be found</param>
        /// <returns>If buffer contains pattern then the indexes of the occurrences of pattern within buffer; otherwise, null</returns>
        /// <remarks>A single byte in the buffer array can only be part of one match.  For example, if searching for 1,2,1 in 1,2,1,2,1 only zero would be returned.</remarks>
        public static int[] ByteArrayPatternIndex(byte[] buffer, byte[] pattern)
        {
            if (buffer != null && pattern != null && pattern.Length <= buffer.Length)
            {
                List<int> indexes = new List<int>();
                int resumeIndex;
                for (int i = 0; i <= buffer.Length - pattern.Length; i++)
                {
                    if (buffer[i] == pattern[0]) // Current byte equals first byte of pattern
                    {
                        resumeIndex = 0;
                        for (int x = 1; x < pattern.Length; x++)
                        {
                            if (buffer[i + x] == pattern[x])
                            {
                                if (x == pattern.Length - 1)  // Matched the entire pattern
                                    indexes.Add(i);
                                else if (resumeIndex == 0 && buffer[i + x] == pattern[0])  // The current byte equals the first byte of the pattern so start here on the next outer loop iteration
                                    resumeIndex = i + x;
                            }
                            else
                            {
                                if (resumeIndex > 0)
                                    i = resumeIndex - 1;  // The outer loop iterator will increment so subtract one
                                else if (x > 1)
                                    i += (x - 1);  // Advance the outer loop variable since we already checked these bytes
                                break;
                            }
                        }
                    }
                }
                if (indexes.Count > 0)
                    return indexes.ToArray();
            }
            return null;
        }

    public static class StringExtensions
        {
            /// <summary>
            /// Returns a Subset string starting at the specified start index and ending and the specified end
            /// index.
            /// </summary>
            /// <param name="s">The string to retrieve the subset from.</param>
            /// <param name="startIndex">The specified start index for the subset.</param>
            /// <param name="endIndex">The specified end index for the subset.</param>
            /// <returns>A Subset string starting at the specified start index and ending and the specified end
            /// index.</returns>
            public static string Subsetstring(this string s, int startIndex, int endIndex)
            {
                if (startIndex > endIndex)
                {
                    throw new InvalidOperationException("End Index must be after Start Index.");
                }
    
                if (startIndex < 0)
                {
                    throw new InvalidOperationException("Start Index must be a positive number.");
                }
    
                if(endIndex <0)
                {
                    throw new InvalidOperationException("End Index must be a positive number.");
                }
    
                return s.Substring(startIndex, (endIndex - startIndex));
            }
    
            /// <summary>
            /// Finds the specified Start Text and the End Text in this string instance, and returns a string
            /// containing all the text starting from startText, to the begining of endText. (endText is not
            /// included.)
            /// </summary>
            /// <param name="s">The string to retrieve the subset from.</param>
            /// <param name="startText">The Start Text to begin the Subset from.</param>
            /// <param name="endText">The End Text to where the Subset goes to.</param>
            /// <param name="ignoreCase">Whether or not to ignore case when comparing startText/endText to the string.</param>
            /// <returns>A string containing all the text starting from startText, to the begining of endText.</returns>
            public static string Subsetstring(this string s, string startText, string endText, bool ignoreCase)
            {
                if (string.IsNullOrEmpty(startText) || string.IsNullOrEmpty(endText))
                {
                    throw new ArgumentException("Start Text and End Text cannot be empty.");
                }
                string temp = s;
                if (ignoreCase)
                {
                    temp = s.ToUpperInvariant();
                    startText = startText.ToUpperInvariant();
                    endText = endText.ToUpperInvariant();
                }
                int start = temp.IndexOf(startText);
                int end = temp.IndexOf(endText, start);
                return Subsetstring(s, start, end);
            }
        }

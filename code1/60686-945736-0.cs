    public static int CountStringOccurrences(string text, string pattern)
            {
                // Loop through all instances of the string 'text'.
                int count = 0;
                int i = 0;
                while ((i = text.IndexOf(pattern, i)) != -1)
                {
                    i += pattern.Length;
                    count++;
                }
                return count;
            }

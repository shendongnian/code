        static string RemoveConsecutiveSpaces(string input)
        {
            bool whiteSpaceWritten = false;
            StringBuilder sbOutput = new StringBuilder(input.Length);
            foreach (Char c in input)
            {
                if (c == ' ')
                {
                    if (!whiteSpaceWritten)
                    {
                        whiteSpaceWritten = true;
                        sbOutput.Append(c);
                    }
                }
                else
                {
                    whiteSpaceWritten = false;
                    sbOutput.Append(c);
                }
            }
            return sbOutput.ToString();
        }

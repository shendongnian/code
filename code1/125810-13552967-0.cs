    public static string RemoveMultipleWhiteSpaces(string s)
        {
            char[] sResultChars = new char[s.Length];
            bool isWhiteSpace = false;
            int sResultCharsIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (!isWhiteSpace)
                    {
                        sResultChars[sResultCharsIndex] = s[i];
                        sResultCharsIndex++;
                        isWhiteSpace = true;
                    }
                }
                else
                {
                    sResultChars[sResultCharsIndex] = s[i];
                    sResultCharsIndex++;
                    isWhiteSpace = false;
                }
            }
            return new string(sResultChars, 0, sResultCharsIndex);
        }

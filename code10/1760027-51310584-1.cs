    using System;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            string text = "This string contains the unicode character bomb (\U0001F4A3)";
            Console.WriteLine(ReplaceNonBmpWithHex(text));
        }
        
        static string ReplaceNonBmpWithHex(string input)
        {
            // TODO: If most string don't have any non-BMP characters, consider
            // an optimization of checking for high/low surrogate characters first,
            // and return input if there aren't any.
            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                // A surrogate pair is a high surrogate followed by a low surrogate
                if (char.IsHighSurrogate(c))
                {
                    if (i == input.Length -1)
                    {
                        throw new ArgumentException($"High surrogate at end of string");
                    }
                    // Fetch the low surrogate, advancing our counter
                    i++;
                    char d = input[i];
                    if (!char.IsLowSurrogate(d))
                    {
                        throw new ArgumentException($"Unmatched low surrogate at index {i-1}");
                    }
                    uint highTranslated = (uint) ((c - 0xd800) * 0x400);
                    uint lowTranslated = (uint) (d - 0xdc00);
                    uint utf32 = (uint) (highTranslated + lowTranslated + 0x10000);
                    builder.AppendFormat("U{0:X8}", utf32);
                }
                // We should never see a low surrogate on its own
                else if (char.IsLowSurrogate(c))
                {
                    throw new ArgumentException($"Unmatched low surrogate at index {i}");
                }
                // Most common case: BMP character; just append it.
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }

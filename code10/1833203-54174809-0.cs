private static string RemoveInvalidCharacters(string input)
        {
            while (true)
            {
                var start = input.IndexOf('\u0004');
                if (start == -1) break;
                if (input[start + 1] == '<')
                {
                    input = input.Remove(start, 2);
                    continue;
                }
                if (input[start + 2] == '\u0003')
                {
                    input = input.Remove(start, 4);
                }
            }
            return input;
        }
A further cleanup with this code:
static string StripExtended(string arg)
        {
            StringBuilder buffer = new StringBuilder(arg.Length); //Max length
            foreach (char ch in arg)
            {
                UInt16 num = Convert.ToUInt16(ch);//In .NET, chars are UTF-16
                //The basic characters have the same code points as ASCII, and the extended characters are bigger
                if ((num >= 32u) && (num <= 126u)) buffer.Append(ch);
            }
            return buffer.ToString();
        }
And now everything looks fine to parse.

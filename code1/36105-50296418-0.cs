        public static unsafe List<string> SplitString(char separator, string input)
        {
            List<string> result = new List<string>();
            char* buffer = stackalloc char[input.Length + 1];
            int i = 0;
            foreach (char c in input)
            {
                if (c == separator)
                {
                    buffer[i] = (char)0;
                    result.Add(new String(buffer));
                    i = 0;
                }
                else
                {
                    buffer[i] = c;
                    i++;
                }
            }
            buffer[i] = (char)0;
            result.Add(new String(buffer));
            return result;
        }

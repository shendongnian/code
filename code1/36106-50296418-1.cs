        public static unsafe List<string> SplitString(char separator, string input)
        {
            List<string> result = new List<string>();
            int i = 0;
            fixed(char* buffer = input)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (buffer[j] == separator)
                    {
                        buffer[i] = (char)0;
                        result.Add(new String(buffer));
                        i = 0;
                    }
                    else
                    {
                        buffer[i] = buffer[j];
                        i++;
                    }
                }
                buffer[i] = (char)0;
                result.Add(new String(buffer));
            }
            return result;
        }

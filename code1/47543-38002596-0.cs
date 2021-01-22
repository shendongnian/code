            public static string ToBinary(this string data, bool formatBits = false)
            {
                char[] buffer = new char[(((data.Length * 8) + (formatBits ? (data.Length - 1) : 0)))];
                int index = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    string binary = Convert.ToString(data[i], 2).PadLeft(8, '0');
                    for (int j = 0; j < 8; j++)
                    {
                        buffer[index] = binary[j];
                        index++;
                    }
                    if (formatBits && i < (data.Length - 1))
                    {
                        buffer[index] = ' ';
                        index++;
                    }
                }
                return new string(buffer);
            }

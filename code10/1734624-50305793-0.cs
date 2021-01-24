        public static string[] SplitBy(string str, int count)
        {
            var some = new string[str.Length/count];
            int i = 0;
            while (true)
            {
                try
                {
                    string temp = str.Substring(i * 8, count);
                    if (temp != null)
                    {
                        some[i] = temp;
                        i++;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            return some;
        }

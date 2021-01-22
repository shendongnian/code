        private static string StringToAsciiBin(string s)
        {
            string output = "";
            foreach (char c in s.ToCharArray())
            {
                for (int i = 128; i >= 1; i /=2)
                {
                    if (((int)c & i) > 0)
                    {
                        output += "1";
                    }
                    else
                    {
                        output += "0";
                    }
                }
            }
            return output;
        }

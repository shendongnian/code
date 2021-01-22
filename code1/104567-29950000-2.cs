        private static string unpack(string p1, string input)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                string a = Convert.ToInt32(input[i]).ToString("X");
                output.Append(a);
            }
            return output.ToString();
        }

    public static string GetXOR(string input)
    {
        if (input.Length % 2 == 0)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i = i + 2)
            {
                string hex = input.Substring(i, 2);
                int hexInt = Convert.ToInt32(hex, 16);
                result ^= hexInt;
            }
            return result.ToString("X");
        }
        return "Wrong Input";
    }

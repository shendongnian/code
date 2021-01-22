    public static class UsernameTools
    {
        public static string GenerateRandomUsername(int length = 10)
        {
            Random random = new Random();
            StringBuilder sbuilder = new StringBuilder();
            for (int x = 0; x < length; ++x)
            {
                sbuilder.Append((char)random.Next(33, 126));
            }
            return sbuilder.ToString();
        }
    }

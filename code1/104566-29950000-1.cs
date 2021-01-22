        private static string md5(string input)
        {
            byte[] asciiBytes = Encoding.Default.GetBytes(input);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString;
        }

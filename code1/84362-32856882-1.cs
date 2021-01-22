            public static string GenerateRandomString(int length)
            {
                var numArray = new byte[length];
                new RNGCryptoServiceProvider().GetBytes(numArray);
                return CleanUpBase64String(Convert.ToBase64String(numArray), length);
            }
    
            private static string CleanUpBase64String(string input, int maxLength)
            {
                input = input.Replace("-", "");
                input = input.Replace("=", "");
                input = input.Replace("/", "");
                input = input.Replace("+", "");
                input = input.Replace(" ", "");
                while (input.Length < maxLength)
                    input = input + GenerateRandomString(maxLength);
                return input.Length <= maxLength ?
                    input.ToUpper() : //In my case I want capital letters
                    input.ToUpper().Substring(0, maxLength);
            }

        // Creates fairly easy-to-remember random passwords, consisting of 
        // three syllables (consonnant + vowel) and two digits at the end.
        // A total of 172'800'000 combinations is possible.
        public static string GeneratePassword()
        {
            const string consonnants = "bcdfghjklmnpqrstvwxz";
            const string vowels = "aeiouy";
            string password = "";
            byte[] bytes = new byte[4];
            var rnd = new RNGCryptoServiceProvider();
            for (int i=0; i<3; i++)
            {
                rnd.GetNonZeroBytes(bytes);
                password += consonnants[bytes[0]*bytes[1] % consonnants.Length];
                password += vowels     [bytes[2]*bytes[3] % vowels.Length];
            }
            rnd.GetBytes(bytes);
            password += (bytes[0] % 10).ToString() + (bytes[1] % 10).ToString();
            return password;
        }

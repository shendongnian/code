            var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            byte[] buffer = new byte[4];
            char[] chars = new char[CharactersCount];
            for(int i = 0 ; i < chars.Length ; i++)
            {
                rng.GetBytes(buffer);
                int nxt = BitConverter.ToInt32(buffer, 0);
                int index = nxt % Alphabet.Length;
                if(index < 0) index += Alphabet.Length;
                chars[i] = Alphabet[index];
            }
            string s = new string(chars);

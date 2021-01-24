            string path = "..\\..\\test.txt";
            byte[] key = null;
            byte[] iv = null;
            using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
            {
                key = myAes.Key;
                iv = myAes.IV;
            }
            using (MyCryptoStream ur = new MyCryptoStream(path, MyCryptoStream.Mode.Write, key, iv))
            {
                using (StreamWriter sw = new StreamWriter(ur.cryptoStream))
                {
                    sw.Write("Test string");
                }
            }
            string text = string.Empty;
            using (MyCryptoStream ur = new MyCryptoStream(path, MyCryptoStream.Mode.Read, key))
            {
                using (StreamReader sr = new StreamReader(ur.cryptoStream))
                {
                    text = sr.ReadToEnd();
                }
            }

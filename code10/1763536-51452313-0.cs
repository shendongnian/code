        public static string TextDecipher(string text)
        {
            string textChars = "@#^*+";
            string decipherText = text;
            char[] specialChars = textChars.ToCharArray();
            for (int i = 0; i < specialChars.Length; i++)
            {
                var charOcurrences = text.ToCharArray().Count(c => c == specialChars[i]);
                if (charOcurrences > 0)
                {
                    for (int j = 0; j < charOcurrences; j++)
                    {
                        var index = decipherText.IndexOf(specialChars[i]);
                        decipherText = decipherText.Remove(index, 1);
                    }
                }
            }
            return decipherText;
        }

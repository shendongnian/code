        public static string TextDecipherWithReplace(string text)
        {
            var specialChars = "@#^*+".ToCharArray();
            var decipherText = text;
            foreach (var specialChar in specialChars)
            {
                decipherText = decipherText.Replace(specialChar.ToString(), "");
            }
            return decipherText;
        }

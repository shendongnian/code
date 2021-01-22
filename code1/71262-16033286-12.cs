    public static class StringHelpers
    {
        public static readonly Random rnd = new Random();
        public static readonly string EnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string RussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public static unsafe string GenerateRandomUTF8String(int length, string alphabet)
        {
            if (length <= 0)
                return String.Empty;
            if (string.IsNullOrWhiteSpace(alphabet))
                throw new ArgumentNullException("alphabet");
            byte[] randomBytes = rnd.NextBytes(length);
            string s = new string(alphabet[0], length);
            fixed (char* p = s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    *(p + i) = alphabet[randomBytes[i] % alphabet.Length];
                }
            }
            return s;
        }
        public static unsafe string GenerateRandomUTF8String(int length, params UnicodeCategory[] unicodeCategories)
        {
            if (length <= 0)
                return String.Empty;
            if (unicodeCategories == null)
                throw new ArgumentNullException("unicodeCategories");
            if (unicodeCategories.Length == 0)
                return rnd.NextString(length);
            byte[] randomBytes = rnd.NextBytes(length);
            string s = randomBytes.ConvertToString();
            fixed (char* p = s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    while (!unicodeCategories.Contains(char.GetUnicodeCategory(*(p + i))))
                        *(p + i) += (char)*(p + i);
                }
            }
            return s;
        }
    }

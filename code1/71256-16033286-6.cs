    public class StringHelpers
    {
        static private readonly Random rnd = new Random();
        static public readonly string EnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        static public readonly string RussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        static public unsafe string GenerateRandomUTF8String(int length, string alphabet)
        {
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
        static public unsafe string GenerateRandomUTF8String(int length, UnicodeCategory[] unicodeCategories)
        {
            if (unicodeCategories == null || unicodeCategories.Length == 0)
                throw new ArgumentNullException("unicodeCategories");
            byte[] randomBytes = rnd.NextBytes(length);
            string s = randomBytes.ConvertToString();
            fixed (char* p = s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    while (!unicodeCategories.Contains(char.GetUnicodeCategory(*(p + i))))
                        *(p + i) += (char)1;
                }
            }
            return s;
        }
    }

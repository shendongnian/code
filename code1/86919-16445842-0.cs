        private static readonly char[] Punctuation = "$€£".ToCharArray();
       
        public static bool IsPrice(this string text)
        {
            return text.IndexOfAny(Punctuation) >= 0;
        }

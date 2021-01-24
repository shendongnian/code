    class Program
    {
        static void Main(string[] args)
        {
            Icu.Wrapper.Init();
            var test = new string[]
            {
                "\ud83c\udff4\udb40\udc67\udb40\udc62\udb40\udc65\udb40\udc6e\udb40\udc67\udb40\udc7f",
                "\U0001F3F4\U000E0067\U000E0062\U000E0065\U000E006E\U000E0067\U000E007F",
                "e\u0301",
                "\U0001F468\U0001F3FF", 
            };
            foreach (var t in test)
            {
                var len = GetLen(t);
                Console.WriteLine(len);
            }
        }
        static int GetLen(string test)
        {
            var ci = Icu.BreakIterator.CreateCharacterInstance(new Icu.Locale("en_US"));
            ci.SetText(test);
            int len = 0;
            while (ci.MoveNext() != Icu.BreakIterator.DONE)
            {
                len++;
            }
            return len;
        }
    }

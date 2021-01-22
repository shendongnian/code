    public class CaseInsensitiveCharComparer : IComparer<char> {
        private readonly System.Globalization.CultureInfo ci;
        public CaseInsensitiveCharComparer(System.Globalization.CultureInfo ci) {
            this.ci = ci;
        }
        public CaseInsensitiveCharComparer()
            : this(System.Globalization.CultureInfo.CurrentCulture) { }
        public int Compare(char x, char y) {
            return Char.ToUpper(x, ci) - Char.ToUpper(y, ci);
        }
    }
    // Prints 3
    Console.WriteLine("This is a test".CountChars('t', new CaseInsensitiveCharComparer()));

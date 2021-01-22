    public class StringWrap
    {
        private string value;
        public StringWrap(string v)
        {
            this.value = v;
        }
        public static string operator *(StringWrap s, int n)
        {
            return s.value.Multiply(n); // DrJokepu extension
        }
    }

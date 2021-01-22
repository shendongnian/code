    class Outer
    {
        internal const string s1 = "@.\bin";
    }
    internal class Nested
    {
        public string FileName
        {
            set
            {
                Outer.s1;field
            }
        }
    }

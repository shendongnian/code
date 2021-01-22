    class SomeClass
    {
        private static string s_foo;   // s_ prefix for static class fields
        private string m_bar;          // m_ prefix for instance class fields
    
        public static string Foo
        {
            get { return s_foo; }
        }
    
        public string Bar
        {
            get { return m_bar; }
        }
    }

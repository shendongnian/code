    class YourClass {
        public class Nested {
            public Nested(YourClass outer) { m_RefToOuterWorld = outer; }
            private readonly YourClass m_RefToOuterWorld;
    
            public string this[int index] {
                get { return m_RefToOuter.TestArray[index];
                set { m_RefToOuter.TestArray[index] = value; }
            }
        }
    
        private readonly Nested m_Nested;
        private string[] TestArray = new string[10];
    
        public YourClass() { m_Nested = new Nested(this); }
    
        public Nested TestIt { get { return m_Nested; } }
    }

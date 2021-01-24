    public class TestAttribute : PropertyAttribute
    {
        public string content;
        public int maxlineCount;
    
        private TestAttribute() { }
        public TestAttribute(string content, int maxlineCount)
        {
            this.content = content;
            this.maxlineCount = maxlineCount;
        }
    }

    static class Program
    {
        static void Main() {
            Test anyObject = new Test();
            anyObject.Type = "abc";
        }
    }
    class Test
    {
        public string Type;
    }

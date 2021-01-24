    class Program
    {
        static void Main(string[] args)
        {
            var sc = new SomeClass();
            sc.ProcessTokens("aa bb");
        }
    }
    class SomeClass
    {
        private Dictionary<string, Action> actions = new Dictionary<string, Action>();
        private int someContext = 0;
        public SomeClass()
        {
            actions["aa"] = DoA;
            actions["bb"] = DoB;
        }
        public void ProcessTokens(string tokens)
        {
            foreach (var token in tokens.Split(' '))
                actions[token]();
        }
        private void DoA()
        {
            someContext++;
            Console.Write("A" + someContext.ToString());
        }
        private void DoB()
        {
            someContext++;
            Console.Write("B" + someContext.ToString());
        }

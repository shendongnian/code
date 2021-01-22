    class DelegateTest
    {
        public event Action del;
        public void Chaining()
        {
            del += () => Console.WriteLine("Hello World");
            del += () => Console.WriteLine("Good Things");
            del += () => Console.WriteLine("Wonderful World");
            del();
        }
    }

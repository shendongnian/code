    public class ConsoleColorBlock : IDisposable
    {
        private readonly ConsoleColor _c2;
        public ConsoleColorBlock(ConsoleColor c1, ConsoleColor c2)
        {
            Console.ForegroundColor = c1;
            _c2 = c2;
        }
    
        public void Dispose()
        {
            Console.ForegroundColor = _c2;
        }
    }

    public class ConsoleColorBlock : IDisposable
    {
        private readonly ConsoleColor _originalColor;
        public ConsoleColorBlock(ConsoleColor color)
        {
            _originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
        }
    
        public void Dispose()
        {
            Console.ForegroundColor = _originalColor;
        }
    }

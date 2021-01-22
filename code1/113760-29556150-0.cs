    public sealed class Spinner
    {
        private static Lazy<Spinner> lazy =
            new Lazy<Spinner>(()=> new Spinner());
        public static void Reset()
        {
            lazy = new Lazy<Spinner>(()=> new Spinner());
        }
        public static Spinner Instance { get { return lazy.Value; }}
        private readonly int _consoleX;
        private readonly int _consoleY;
        private readonly char[] _frames = { '|', '/', '-', '\\' };
        private int _current;
        private Spinner()
        {
            _current = 0;
            _consoleX = Console.CursorLeft;
            _consoleY = Console.CursorTop;
        }
        public void Update()
        {
            Console.Write(_frames[_current]);
            Console.SetCursorPosition(_consoleX, _consoleY);
            if (++_current >= _frames.Length)
                _current = 0;
        }
    }

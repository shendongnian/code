    public class Game
    {
        private Element _element = null;
        public Game()
        {
            _element = new Element(state1);
        }
        internal void state1()
        {
            Console.WriteLine("Executing state1 code");
        }
        internal void state2()
        {
            Console.WriteLine("Executing state2 code");
        }
    }
    public class Element
    {
        public delegate void FunctionPointer();
        private FunctionPointer _function = null;
        public Element(FunctionPointer function)
        {
            _function = new FunctionPointer(function);
            _function();            
        }
    }

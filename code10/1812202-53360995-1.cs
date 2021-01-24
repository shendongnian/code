    public interface IGame
    {
        void state1();
        void state2();
    }
    public class Game : IGame
    {
        private Element _element = null;
        public Game()
        {
            _element = new Element(this);
        }
        public void state1()
        {
            Console.WriteLine("Executing state1 code");
        }
        public void state2()
        {
            Console.WriteLine("Executing state1 code");
        }
    }
    public class Element
    {
        private IGame _game = null;
        public Element(IGame game)
        {
            _game = game;
            _game.state1();
        }
    }

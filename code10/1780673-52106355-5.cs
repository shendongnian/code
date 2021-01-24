    public class SnakeGame {
        private readonly int _gameSpeed = 1000;
        private static Timer _updatePositionTimer;
        private bool _gameOver = false;
    
        public Movement Movement {get;}
        public Food Food {get;}
        public Body Body {get;}
        public Display Display {get;}
        public Draw Draw {get;}
        public SnakeGame(ISenseHat senseHat)
        {
            Movement = new Movement(this);
            Food = new Food(this);
            Body = new Body(this);
            Display = new Display(this);
            Draw = new Draw(this);
        }
        //More code
    }
    
    public abstract class GameObject {
        protected readonly SnakeGame game;
        protected GameObject(SnakeGame game) {
            this.game = game;
        }
    }
    
    public class Movement : GameObject
    {
        public Movement(SnakeGame game)
        : base(senseHat)
        {
        }
        //More code
    }

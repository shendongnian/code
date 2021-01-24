    public class SnakeGame : SenseHatSnake
    {
        private readonly int _gameSpeed = 1000;
        private static Timer _updatePositionTimer;
        private bool _gameOver = false;
    
        public readonly Movement Movement = new Movement(SenseHat);
        public readonly Food Food = new Food(SenseHat);
        public readonly Body Body = new Body(SenseHat);
        public readonly Display Display = new Display(SenseHat);
        public readonly Draw Draw = new Draw(SenseHat);
    
        public SnakeGame(ISenseHat senseHat)
        : base()
        {
            Movement = new Movement(senseHat);
            Food = new Food(senseHat);
            Body = new Body(senseHat);
            Display = new Display(senseHat);
            Draw = new Draw(senseHat);
        }
        //More code
    }

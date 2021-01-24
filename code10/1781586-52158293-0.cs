    /// <summary>
    /// Invaders, that can move and be shot
    /// </summary>
    public class ArmyOfInvaders
    {
        /// <summary>
        /// Alive invaders
        /// </summary>
        private readonly List<Invader> _invaders = new List<Invader>();
        /// <summary>
        /// Initializes all invaders once on start of the game
        /// Provide them initial coordinates and add them to <see cref="_invaders"/>
        /// </summary>
        public void Initialize()
        {
        }
        /// <summary>
        /// Moves all invaders somewhere
        /// Erases invaders, moves them and draw again
        /// </summary>
        public void Move()
        {
            int xMove = 0;
            int yMove = 0;
            // Here some logic around moving of entire cloud of invaders
            // computing of xMove and yMove
            foreach (var invader in _invaders)
            {
                invader.Erase();
                invader.Move(xMove, yMove);
                invader.Draw();
            }
        }
        /// <summary>
        /// Handles shoot to invaders
        /// </summary>
        /// <param name="shootX">X coordinate of the bullet</param>
        /// <param name="shootY">Y coordinate of the bullet</param>
        public void HandleShoot(int shootX, int shootY)
        {
            var victim = _invaders.FirstOrDefault(i => i.IsShot(shootX, shootY));
            if (victim != null)
            {
                _invaders.Remove(victim);
            }
        }
    }
    /// <summary>
    /// Single invader
    /// </summary>
    /// <remarks>
    /// Invader really needs only one postion(x,y), let say top-left point
    /// All symbols, which it consists of, can be printed relatively of this point.
    /// </remarks>
    public class Invader
    {
        /// <summary>
        /// X coordinate of invader
        /// </summary>
        private int _x;
        
        /// <summary>
        /// Y coordinate of invader
        /// </summary>
        private int _y;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="x">Initial x coordinate</param>
        /// <param name="y">Initial y coordinate</param>
        public Invader(int x, int y)
        {
            Move(x, y);
        }
        /// <summary>
        /// Draws the invader by current coordinates
        /// Invader really needs only one postion(x,y), let say top-left point
        /// All symbols, which it consists of, can be printed relatively of this point.
        /// </summary>
        public void Draw()
        {
            // here printing of symbols
        }
        /// <summary>
        /// Changes the coordinates of invader
        /// </summary>
        public void Move(int xMove, int yMove)
        {
            _x += xMove;
            _y += yMove;
        }
        /// <summary>
        /// Erases the invader by current coordinates
        /// </summary>
        public void Erase()
        {
            // here erasing of symbols
        }
        /// <summary>
        /// Returns true if some part of invaders is crushed by bullet
        /// </summary>
        /// <param name="shootX">X coordinate of bullet</param>
        /// <param name="shootY">Y coordinate of bullet</param>
        public bool IsShot(int shootX, int shootY)
        {
            return // here logic of crushing
        }
    }

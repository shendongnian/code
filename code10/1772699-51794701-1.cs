    public partial class Form1 : Form
    {
        // Program Settings and Controls
        private readonly Panel pnlBacteria;             // Panel representing a piece of bacteria
        private readonly Random random = new Random();  // For randomly-generated values
        private readonly Timer tmrMoveBackteria;        // Timer used for bacteria movement
        private readonly int bacteriaSize = 20;         // The bacteria size
        private const int maxDistance = 100;            // The maximum number of moves allowed in the same direction.
        private const int stepDistance = 2;             // The distance to travel on each iteration of the timer. Smaller number is slower and smoother
        // Bacteria state variables
        private Direction direction;  // The current direction bacteria is moving
        private int distance;         // The distance remaining to travel in the current direction
        // Represents possible directions for bacteria to move
        private enum Direction
        {
            North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest
        }
        public Form1()
        {
            InitializeComponent();
            // Give life to the bacteria
            pnlBacteria = new Panel
            {
                BackColor = Color.Red,
                Width = bacteriaSize,
                Height = bacteriaSize,
                Left = random.Next(0, ClientRectangle.Width - bacteriaSize),
                Top = random.Next(0, ClientRectangle.Height - bacteriaSize)
            };
            Controls.Add(pnlBacteria);
            // Start bacteria movement timer
            tmrMoveBackteria = new Timer {Interval = 10};
            tmrMoveBackteria.Tick += TmrMoveBacteria_Tick;
            tmrMoveBackteria.Start();
        }
        /// <summary>
        /// Sets the direction and distance fields to valid values based on the
        /// current bacteria position, direction, and remaining distance
        /// </summary>
        private void UpdateDirectionAndDistance()
        {
            // Get all directions
            var validDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            // Remove invalid directions (based on the bacteria position)
            if (pnlBacteria.Top < bacteriaSize) validDirections = 
                validDirections.Where(dir => !dir.ToString().Contains("North"));
            if (pnlBacteria.Right > ClientRectangle.Width - bacteriaSize) validDirections = 
                validDirections.Where(dir => !dir.ToString().Contains("East"));
            if (pnlBacteria.Left < bacteriaSize) validDirections = 
                validDirections.Where(dir => !dir.ToString().Contains("West"));
            if (pnlBacteria.Bottom > ClientRectangle.Height - bacteriaSize) validDirections = 
                validDirections.Where(dir => !dir.ToString().Contains("South"));
        
            // If we're supposed to keep on moving in the same 
            // direction and it's valid, then we can exit
            if (distance > 0 && validDirections.Contains(direction)) return;
            // If we got here, then we're setting a new direction and distance
            distance = GetRandomWeightedDistance();
            var directions = validDirections.Where(d => d != direction).ToList();
            direction = directions[random.Next(directions.Count)];
        }
        /// <summary>
        /// Chooses a random distance, giving heavier weight to the smaller distances
        /// So 1 will be chosen 5/15 of the time, 2 = 4/15, 3 = 3/15, 4 = 2/15, and 5 = 1/15
        /// </summary>
        /// <returns>A new distance value</returns>
        private int GetRandomWeightedDistance()
        {
            // Create a weighted list of distances so that 1 is chosen most 
            // often and maxDistance is chosen the least often
            var weightedDistances = new List<int>();
            for (var i = 0; i < maxDistance; i++)
            {
                for (var j = 0; j < maxDistance - i; j++)
                {
                    weightedDistances.Add(i + 1);
                }
            }
            return weightedDistances[random.Next(weightedDistances.Count)];
        }
        /// <summary>
        /// Executes on each iteration of the timer, and moves the bacteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrMoveBacteria_Tick(object sender, EventArgs e)
        {
            // Ensure direction and distance are valid
            UpdateDirectionAndDistance();
            // Move the bacteria
            var dirStr = direction.ToString();
            if (dirStr.Contains("North")) pnlBacteria.Top -= stepDistance;
            if (dirStr.Contains("East")) pnlBacteria.Left += stepDistance;
            if (dirStr.Contains("South")) pnlBacteria.Top += stepDistance;
            if (dirStr.Contains("West")) pnlBacteria.Left -= stepDistance;
            distance -= 1;
        }
    }

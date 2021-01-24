    public partial class Form1 : Form
    {
        // Program Settings and Controls
        private readonly Panel pnlBacteria;             // Panel representing a piece of bacteria
        private readonly Random random = new Random();  // For randomly-generated values
        private readonly Timer tmrMoveBacteria;        // Timer used for bacteria movement
        private readonly int bacteriaSize = 20;         // Stores the size for our bacteria
        private const int maxDistance = 50;             // The maximum number of moves allowed in the same direction.
        private const int stepDistance = 3;             // The distance to travel on each iteration of the timer. Smaller number is slower and smoother
        private readonly List<int> weightedDistances;   // Contains a weighted list of distances (lower numbers appear more often than higher ones)
        // Bacteria state variables
        private Direction direction;  // Stores the current direction bacteria is moving
        private int distance;         // Stores the distance remaining to travel in current direction
        // Represents possible directions for bacteria to move
        private enum Direction
        {
            North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest
        }
        public Form1()
        {
            InitializeComponent();
            // Initialize our weighted differences array so that 1 is  
            // chosen most often and maxDistance is chosen the least often
            weightedDistances = new List<int>();
            for (var i = 0; i < maxDistance; i++)
            {
                var weight = maxDistance / (i + 1);
                for (var j = 0; j <= weight; j++)
                {
                    weightedDistances.Add(i + 1);
                }
            }
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
            tmrMoveBacteria = new Timer {Interval = 10};
            tmrMoveBacteria.Tick += TmrMoveBacteria_Tick;
            tmrMoveBacteria.Start();
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
            distance = weightedDistances[random.Next(weightedDistances.Count)];
            var directions = validDirections.Where(d => d != direction).ToList();
            direction = directions[random.Next(directions.Count)];
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
            distance--;
        }
    }

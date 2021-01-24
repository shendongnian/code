    public partial class Game : Form
    {
        public string playerXName,
                      playerOName;
    
        public Game(string player1, string player2)
        {
            InitializeComponent();
            playerXName = player1;
            playerOName = player2;
            WhosTurnLabel.Text = $"{playerXName}'s Turn";
        }
    }

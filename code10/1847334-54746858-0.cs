    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }
        private string _playerName = "";
        private void button3_Click(object sender, EventArgs e)
        {
            using (NewPlayer np = new NewPlayer())
            {
                if (np.ShowDialog() == DialogResult.OK)
                {
                    _playerName = np.PlayerName;
                    MessageBox.Show($"Welcome {_playerName}!");
                }
            }
        }
    }

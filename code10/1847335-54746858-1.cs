    public partial class NewPlayer : Form
    {
        public NewPlayer()
        {
            InitializeComponent();
        }
        private string _playerName = "";
        public string PlayerName
        {
            get { return _playerName; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedIndex > -1)
            {
                _playerName = $"{textBox1.Text}{comboBox1.SelectedIndex}";
                MessageBox.Show(_playerName);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Write your name and choose a color!");
            }
        }
    }

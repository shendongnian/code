    public partial class Confirmation : Form
    {
        public Form Menu {get; set;}
        public Confirmation()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        public void SetProperties(string color)
        {
           // do your logic here 
        }
        private void Confirmation_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Menu != null)
            {
                Menu.Show();
                Menu.BringToFront();
            }
        }
    }

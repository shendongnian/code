    public class Titles
    {
        private string x;
        public Titles(string strToDisplay)
        {
            InitializeComponent();
            this.x = strToDisplay;
        }
        private void titleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newX = this.x;
        }
    }

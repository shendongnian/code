    class Titles
    {
        private string strToDisplayField;
        public Titles(string strToDisplay)
        {
            InitializeComponent();
            strToDisplayField = strToDisplay;
        }
    
    
        private void titleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var local = strToDisplayField; // Is accessible here
        }
    }

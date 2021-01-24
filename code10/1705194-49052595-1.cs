    public class Titles
    {
        public string X { get; set; }
        public Titles(string strToDisplay)
        {
            InitializeComponent();
            this.X = strToDisplay;
        }
    }
    
    public class AnotherClass
    {
        private void titleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = new Titles("Some text");
            var newX = t.X;
        }
    }

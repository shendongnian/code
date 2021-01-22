        public Form1()
        {
            InitializeComponent();
            string text = GetText();
        }
        private string GetText()
        {
            string text;
            Invoke(new Action(text = txtBox.Text));
            return text;
        }

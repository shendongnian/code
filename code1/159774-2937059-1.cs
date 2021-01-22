        public Form1()
        {
            InitializeComponent();
            Invoke(new Action(SetTextboxTextVariable));
        }
        private string _text;
        private void SetTextboxTextVariable()
        {
            _text = txtBox.Text;
        } 

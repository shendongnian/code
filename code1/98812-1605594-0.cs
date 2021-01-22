    public partial class PreTextBox : TextBox
    {
        public PreTextBox()
        {
            InitializeComponent();
            Text = PreText;
            ForeColor = Color.Gray;
        }
        public string PreText
        {
            set{Text = value;} 
            get{return Text;}
        }
    }

    public partial class Sample: UserControl
    {
        public event EventHandler TextboxValidated;
    
        public Sample()
        {
            InitializeComponent();
        }
    
    
        private void TextBox_Validated(object sender, EventArgs e)
        {
            // invoke UserControl event here
            if (this.TextboxValidated != null) this.TextboxValidated(sender, e);
        }
    }

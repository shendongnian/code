    public partial class CustomButton: Button
    {
        public ButtonPageButton()
        {
            InitializeComponent();
    
            this.SetStyle(ControlStyles.Selectable, false);
        }
    }

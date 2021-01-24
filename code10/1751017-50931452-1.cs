    public partial class us1 : UserControl
    {
        // Property to hold the us2 control.
        public us2 us2 { get; set; }
        public us1()
        {
            InitializeComponent();
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Bring the other control to the front if the property has been set.
            us2?.BringToFront();
        }
    }

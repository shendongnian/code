    public partial class MyCustomControl : UserControl
    {
        public MyCustomControl()
        {
            InitializeComponent();
        }
        public string MyCustomProperty
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
    }

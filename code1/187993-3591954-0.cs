    public partial class UserControl1 : UserControl
    {
        public TestNestedOption TestOption { get; set; }
        public UserControl1()
        {
            InitializeComponent();
            TestOption = new TestNestedOption();
        }
    }

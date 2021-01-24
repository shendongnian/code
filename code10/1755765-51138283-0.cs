    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Title = "W 1";
            ShowDialog();
        }
    }
    public partial class Window2 : Window1
    {
        public Window2()
        {
            InitializeComponent();
            Title = "W 2";
        }
    }

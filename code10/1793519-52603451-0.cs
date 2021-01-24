    public partial class Window1 : Window
    {
        public int ipp { get; set; }
        public Window1()
        {
            ipp = 30;
            InitializeComponent();
            DataContext = this;
        }
    }

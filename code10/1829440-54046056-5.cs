    public class MyView : Window
    {
        public MyView()
        {
            InitializeComponent();
            DataContext = new MyViewModel();
        }
    }

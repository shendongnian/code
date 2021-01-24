    public class ViewModel
    {
        public void Foo()
        {
        }
    }
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new ViewModel();
        }

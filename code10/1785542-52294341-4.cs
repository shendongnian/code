    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }
        public Page2(string entry)
        {
            InitializeComponent();
            BindingContext = new Page2ViewModel(entry);
        }
    }

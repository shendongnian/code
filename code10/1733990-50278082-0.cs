    class MyPage
    {
        ViewModel vm;
    
        public MyPage(int id)
        {
            InitializeComponent();
            vm = new ViewModel(id);
            BindingContext = vm;
        }
    }

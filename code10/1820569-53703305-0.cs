      public SamplePage()
        {
            InitializeComponent();
            BindingContext = new Project_View_ViewModel(Navigation);
        }

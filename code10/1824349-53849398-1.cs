    public SamplePage()
        {
            InitializeComponent();
            BindingContext = SampleViewModel.CurrentInstance(Navigation);
        }

    public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private ObservableCollection<Wrapper> myCollection = new ObservableCollection<Wrapper>()
            {new Wrapper(true), new Wrapper(false), new Wrapper(true)};
        public ObservableCollection<Wrapper> MyCollection
        {
            get { return myCollection; }
        }

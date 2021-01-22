        public Window1()
        {
            InitializeComponent();
            myItems.ItemsSource = new[] {
                new {MyRow = 0, MyColumn = 0, MyText="top left"},
                new {MyRow = 1, MyColumn = 1, MyText="middle"},
                new {MyRow = 2, MyColumn = 2, MyText="bottom right"}
            };
        }

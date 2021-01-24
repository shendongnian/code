    Using System;
    
    ObservablledCollection<Child> childs = new ObservableCollection<Child>;
        public MainWindow()
        {
            childs = new ChildCollection();            
            InitializeComponent();
            DataContext = childs;
        }

        ObservableCollection<Emp> _empList = new ObservableCollection<Emp>();
        public Window1()
        {
            InitializeComponent();
            _empList .Add(new Emp("1", 22));
            _empList .Add(new Emp("2", 18));
            _empList .Add(new Emp("3", 29));
            _empList .Add(new Emp("4", 9));
            _empList .Add(new Emp("5", 29));
            _empList .Add(new Emp("6", 9));
            listbox1.DisplayMemberPath = "Name";
            listbox1.ItemsSource = _empList;
            
            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(s_PreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(listbox1_Drop)));
            listbox1.ItemContainerStyle = itemContainerStyle;
        }

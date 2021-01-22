        public Window1()
        {
            InitializeComponent();
            AddressBook book = new AddressBook();
            book.HouseNumber = 123;
            TextBlock tb = new TextBlock();
            Binding bind = new Binding("HouseNumber");
            bind.Source = book;
            bind.Mode = BindingMode.OneWay;
            tb.SetBinding(TextBlock.TextProperty, bind); // Text block displays "123"
            myGrid.Children.Add(tb);
            book.HouseNumber = 456; 
        }
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            AddressBook book = (AddressBook)((TextBlock)myGrid.Children[0]).GetBindingExpression(TextBlock.TextProperty).DataItem;
            book.HouseNumber++;
        }

    public partial class Window1 : Window
    {
        private AddressBook book;
        public Window1()
        {
            InitializeComponent();
            book = new AddressBook();
            book.HouseNumber = 13;
            TextBlock tb = new TextBlock();
            Binding bind = new Binding("HouseNumber");
            bind.Source = book;
            tb.SetBinding(TextBlock.TextProperty, bind);
            myGrid.Children.Add(tb);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            book.HouseNumber = rnd.Next();
        }
    }

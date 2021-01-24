    public partial class Menu : Window
        {
            public delegate void DataChangeHandler(object sender, EventArgs e);
            // an instance of the delegate
            public DataChangeHandler DataChanged;
            public Menu()
            {
                InitializeComponent();
            }
            public static bool Xs { get; private set; }
            public static bool Os { get; private set; }
            public void Button_Click(object sender, RoutedEventArgs e)
            {
                Xs = true;
                Os = false;
                DataChanged?.Invoke(this, new EventArgs());
                this.Close();
            }
    
            public void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Xs = false;
                Os = true;
                MessageBox.Show("Xs is false");
                DataChanged?.Invoke(this, new EventArgs());//when menu closes announce change event if a handler is wired up to listen.
                this.Close();
            }
        }

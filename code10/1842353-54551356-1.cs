public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonConnection(object sender, RoutedEventArgs e)
        {
            var myObj = new Class1();
            myObj.displayTest();
        }
    }
Or you can make the method static and call without creating of instance.
public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonConnection(object sender, RoutedEventArgs e)
        {
            Class1.displayTest();
        }
    }
Also c# allows you to access static members and nested types of a type without having to qualify the access with the type name.
using static ClassLibrary2.Class1;
public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonConnection(object sender, RoutedEventArgs e)
        {
            displayTest();
        }
    }

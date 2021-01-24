        public class TestView
        {
            private bool _test;
            public bool TestProp
            {
                get => _test;
                set
                {
                    Console.WriteLine("Start set value");
                    Thread.Sleep(5000);
                    _test = value;
                    Console.WriteLine("End set value");
                }
            }
        }
        
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new TestView();
            }
    
            private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
            {
                Console.WriteLine("Checked");
            }
    
            private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
            {
                Console.WriteLine("Unchecked");
            }
        }
 

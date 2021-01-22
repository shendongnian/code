    using System.Windows;
    
    namespace CTDExample
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var ctd = new MyCustomType();
                ctd.AddProperty("Name", typeof(string)); // Now takes a Type argument.
                ctd.AddProperty("Age", typeof(int));
                DataContext = ctd;
            }
        }
    }

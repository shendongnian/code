    using System.Linq;
    using System.Reflection;
    using System.Windows;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Title = (Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute)).SingleOrDefault() as AssemblyTitleAttribute)?.Title;
            }
        }
    }

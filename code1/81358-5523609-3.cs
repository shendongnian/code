    namespace TempProj
    {
        using System.Windows;
    
        public partial class MainWindow : Window
        {
            static public readonly PropertyPath BindingPath = new PropertyPath("X");
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }

    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;
    
    namespace TestApp
    {
        public partial class MainWindow : Window
        {           
            public Screen GetCurrentScreen(Window window)
            {
                return Screen.FromHandle(new WindowInteropHelper(window).Handle);
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                var screen = GetCurrentScreen(this);
                var height = screen.Bounds.Height;
                var width = screen.Bounds.Width;
                
                // ...
            }     
        }
    }

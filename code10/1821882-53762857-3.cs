    using System.Windows.Controls;
    
    namespace TestWpfApplication
    {
        internal class MainWindowViewModel
        {
            public UserControl LeftControl { get; } = new LeftControl();
    
            public UserControl RightControl { get; } = new RightControl();
        }
    }

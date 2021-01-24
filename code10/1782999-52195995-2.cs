    using System.Windows.Input;
    
    namespace WpfApp4
    {
        public partial class MainWindow 
        {
            public MainWindow()
            {
                InitializeComponent();
                AddTextblock();
    
                // Not necessary, just want to focus not to the textblock.
                FocusManager.SetFocusedElement(MainGrid, MainGrid);
            }
    
            private void AddTextblock()
            {
                TextblockWithTooltip textblock = new TextblockWithTooltip();
                textblock.DisplayText = "Just another textblock with tooltip.";
                textblock.TooltipText = "This is a long long long tooltip.";
    
                MainGrid.Children.Add(textblock);
            }
        }
    }

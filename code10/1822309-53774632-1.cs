    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreWindow.GetForCurrentThread().KeyDown += MainPage_KeyDown;
            CoreWindow.GetForCurrentThread().KeyUp += MainPage_KeyUp; ;
        }
    
        private void MainPage_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == VirtualKey.Shift)
            {                
                MyScrollViewer.IsScrollInertiaEnabled = true;
                MyScrollViewer.VerticalScrollMode = ScrollMode.Enabled;
            }
        }
    
        private void MainPage_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == VirtualKey.Shift)
            {
                MyScrollViewer.IsScrollInertiaEnabled = false;
                MyScrollViewer.VerticalScrollMode = ScrollMode.Disabled;
            }
        }
     
    }

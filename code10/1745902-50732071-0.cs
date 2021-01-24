        Windows.UI.Core.CoreDispatcher dispatcher;
    
        public MainPage()
        {
            this.InitializeComponent();
            dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        }
    
        private async void updateTextField ()
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, ()=>{
                IncomingMessage.Text = "Update";
            });
    
        }

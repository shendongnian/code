        using Windows.ApplicationModel.Core;
    
        private async void updateTextField ()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, ()=>{
                IncomingMessage.Text = "Update";
            });    
        }

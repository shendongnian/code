    [AllowForWeb]
    public sealed class CallJSCSharp
    {
        public async void OpenURL(string url)
        {
            await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () => { 
                     await Launcher.LaunchUriAsync(new Uri(url)); 
                });
        }
    }

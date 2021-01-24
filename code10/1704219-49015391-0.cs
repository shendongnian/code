    ...
    using Windows.System;
    using Windows.Storage;
    
    namespace MyProject
    {
        public sealed partial class BlankPage2 : Page
        {
            ...
            async private void Button_Click(object sender, RoutedEventArgs e)
            {
                await Launcher.LaunchFolderAsync
                           (ApplicationData.Current.LocalFolder);
            }
        }
    }

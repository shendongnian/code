    private async void MyMedia_Loaded(object sender, RoutedEventArgs e)
    {  
        var control = MyMedia.MediaPlayer.SystemMediaTransportControls;
        control.ButtonPressed += Control_ButtonPressed;
    }
    async void Control_ButtonPressed(SystemMediaTransportControls sender,
        SystemMediaTransportControlsButtonPressedEventArgs args)
    {
        switch (args.Button)
        {
            case SystemMediaTransportControlsButton.Play:
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    mediaElement.Play();
                });
                break;
            case SystemMediaTransportControlsButton.Pause:
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    mediaElement.Pause();
                });
                break;
            default:
                break;
        }
    }

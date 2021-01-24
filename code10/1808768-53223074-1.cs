    public static void Show(object content, NotificationConfiguration configuration)
    {
        DataTemplate notificationTemplate = (DataTemplate)Application.Current.Resources[configuration.TemplateName];
        Window window = new Window()
        {
            Title = "",
            Width = configuration.Width.Value,
            Height = configuration.Height.Value,
            Content = content,
            ShowActivated = false,
            AllowsTransparency = true,
            WindowStyle = WindowStyle.None,
            ShowInTaskbar = false,
            Topmost = true,
            Background = Brushes.Transparent,
            UseLayoutRounding = true,
            ContentTemplate = notificationTemplate
        };
        //Subscribe to clicks
        window.PreviewMouseDown += NotificationWindow_PreviewMouseDoubleClick;
        WPFNotification.Core.NotifyBox.Show(
            window, configuration.DisplayDuration, configuration.NotificationFlowDirection);
    }
    private static void NotificationWindow_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Clicked!!!");
    }

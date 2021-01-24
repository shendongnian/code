    public static DispatcherTimer Pause_ForCreate(Label _ChangeImageEllipse)
    {
        var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        t.Tick += (s, e) => _ChangeImageEllipse.Visibility = Visibility.Visible;
        t.Start();
        return t;
    }

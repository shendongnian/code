    public Server ObservableServers
    {
        get { return (Server)GetValue(ObservableServersProperty); }
        set { SetValue(ObservableServersProperty, value); }
    }
    public static readonly DependencyProperty ObservableServersProperty =
        DependencyProperty.Register("ObservableServers", typeof(Server), typeof(MainClass), new PropertyMetadata(null));

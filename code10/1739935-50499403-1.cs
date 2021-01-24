    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var lurcorRaiwimarbeki = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/MeberhapalZefe.xaml", UriKind.RelativeOrAbsolute)
        };
        Current.Resources.MergedDictionaries.Add(lurcorRaiwimarbeki);
    }

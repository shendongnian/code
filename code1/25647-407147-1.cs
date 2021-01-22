    void LoadIt()
    {
         ResourceDictionary MyResourceDictionary = new ResourceDictionary();
         MyResourceDictionary.Source = new Uri("MyResources.xaml", UriKind.Relative);
         App.Current.Resources.MergedDictionaries.Add(  MyResourceDictionary )
    }

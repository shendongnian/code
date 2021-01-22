    if (Application.Current == null)
    {
        // create the Application object
        new Application();
        // merge in your application resources
        Application.Current.Resources.MergedDictionaries.Add(
            Application.LoadComponent(
                new Uri("MyLibrary;component/Resources/MyResourceDictionary.xaml",
                UriKind.Relative)) as ResourceDictionary);
    }

    public void ChangeTheme(string ThemeName)
    {
         ResourceDictionary dict = new ResourceDictionary();
                    dict.Source = new Uri("..\\Themes\\" + ThemeName + ".xaml", UriKind.Relative);
                    App.Current.Resources.MergedDictionaries.Add(dict);
    }

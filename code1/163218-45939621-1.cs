    public static class ResourceManager
    {
        public static readonly string[] MergedResources = {
            "pack://application:,,,/Tracto.UI.Infrastructure;component/Dictionaries/CommonColors.xaml",
            "pack://application:,,,/Tracto.UI.Infrastructure;component/Dictionaries/CommonStyles.xaml",
            "pack://application:,,,/Tracto.UI.Infrastructure;component/Dictionaries/GridSplitterStyle.xaml"
        };
        public static void AddResources()
        {
            Application.Current.Resources.BeginInit();
            foreach (var resource in MergedResources)
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(resource, UriKind.Absolute)
                });
            }
            Application.Current.Resources.EndInit();
        }
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string skinName = "LightSkin";
            if (((RadioButton)sender).Name == "DarkSkin")
            {
                skinName = "DarkSkin";
            }
            ResourceDictionary resources = new ResourceDictionary();
            resources.Source = new Uri($"pack://application:,,,/MySkinsLibrary;component/Skins/{skinName}.xaml");
            Application.Current.Resources = resources;
        }

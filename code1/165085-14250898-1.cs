            void OnLoad(object sender, RoutedEventArgs e)
        {
            comboBoxUserReadable.ItemsSource = Enum.GetValues(typeof(EMyEnum))
                            .Cast<EMyEnum>()
                            .Select(v => new ComboEnumItem(v))
                            .ToList();
            comboBoxUserReadable.DisplayMemberPath = "Text";
            comboBoxUserReadable.DisplayMemberPath = "Value";
        }

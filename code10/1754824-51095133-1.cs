            var data = new Dictionary<SolidColorBrush,string>();
            data.Add(Brushes.Blue,"Blue");
            data.Add(Brushes.Red,"Red");
            data.Add(Brushes.Green, "Green");
            data.Add(Brushes.Orange, "Orange");
            data.Add(Brushes.Pink, "Pink");
            data.Add(Brushes.Purple, "Purple");
            var pantsColorComboBox = sender as ComboBox;
           
            pantsColorComboBox.ItemsSource = data;
            pantsColorComboBox.SelectedIndex = 0;

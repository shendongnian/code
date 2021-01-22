    private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = sender as ComboBox;
        ComboBoxItem comboBoxItem = comboBox.ItemContainerGenerator.ContainerFromItem(comboBox.SelectedItem) as ComboBoxItem;
        if (comboBoxItem == null)
        {
            return;
        }
        TextBlock textBlock = FindVisualChildByName<TextBlock>(comboBoxItem, "nameTextBlock");
        MessageBox.Show(textBlock.Text);
    }
    
    private static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            string controlName = child.GetValue(NameProperty) as string;
            if (controlName == name)
            {
                return child as T;
            }
            T result = FindVisualChildByName<T>(child, name);
            if (result != null)
                return result;
        }
        return null;
    }

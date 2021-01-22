    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox ContactListBox = sender as ListBox;
            ListBoxItem listBoxItem = ContactListBox .ItemContainerGenerator.ContainerFromItem(ContactListBox.SelectedItem) as ListBoxItem;
            if (listBoxItem == null)
            {
                return;
            }
            TextBlock txtBlock = FindVisualChildByName<TextBlock>(listBoxItem, "ListTextBlock");
           MessageBox.Show(txtBlock.Text);                        
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

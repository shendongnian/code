        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);
            var control = FindChild<CheckBox>(item, "SelectedItemCheckBox");
            control.IsChecked = true;
        }

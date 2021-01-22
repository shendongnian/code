        private void InitItems()
        {
            if (!string.IsNullOrEmpty(ItemTypeIdCode) &&
                !string.IsNullOrEmpty(KeyField) &&
                !string.IsNullOrEmpty(ValueField))
            {
                Items.Clear();
                foreach (var kvp in Datasource.GetInstance().GetKeyValues(ItemTypeIdCode + "(" + KeyField + "," + ValueField + "); all; orderby displayOrder"))
                {
                    Items.Add(new KeyValuePair<string, string>(kvp.Key, kvp.Value));
                }
                this.SelectedIndex = 0;
            }
        }
        private void OnItemTypeIdCodePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            InitItems();
        }
        
        private static void OnKeyFieldPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            DropDown dropDown = dependencyObject as DropDown;
            dropDown.InitItems();
            dropDown.OnPropertyChanged("KeyField");
            dropDown.OnKeyFieldPropertyChanged(e);
        }
        private static void OnValueFieldPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            DropDown dropDown = dependencyObject as DropDown;
            dropDown.InitItems();
            dropDown.OnPropertyChanged("ValueField");
            dropDown.OnValueFieldPropertyChanged(e);
        }

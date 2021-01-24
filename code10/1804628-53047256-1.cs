        private void DataGridRow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var dataGridRow = (DataGridRow)sender;
            if (dataGridRow != null)
            {
                var dataGridRowParent = FindParent<DataGrid>(dataGridRow);
                if (dataGridRowParent != null)
                {
                    dataGridRowParent.SelectedItem = dataGridRow.Item;
                }
            }
        }
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            //we've reached the end of the tree
            if (parentObject == null) return null;
            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

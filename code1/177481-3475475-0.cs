        public DataGridRow TryFindRow(object item, DataGrid grid)
        {
            // Does not de-virtualize cells
            DataGridRow row = (DataGridRow)(grid as ItemsControl).ItemContainerGenerator.ContainerFromItem(item);
           
            return row;
        }

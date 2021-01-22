        void dg_sql_data_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DataGrid myDataGrid = (DataGrid)sender;
            // Do not change column size if Visibility State Changed
            if (myDataGrid.RenderSize.Width != 0)
            {
                double all_columns_sizes = 0.0;
                foreach (DataGridColumn dg_c in myDataGrid.Columns)
                {
                    all_columns_sizes += dg_c.ActualWidth;
                }
                // Space available to fill ( -18 Standard vScrollbar)
                double space_available = (myDataGrid.RenderSize.Width - 18) - all_columns_sizes;
                foreach (DataGridColumn dg_c in myDataGrid.Columns)
                {
                    dg_c.Width = new DataGridLength(dg_c.ActualWidth + (space_available / myDataGrid.Columns.Count));
                }
            }
        }

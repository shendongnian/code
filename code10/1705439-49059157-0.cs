        private void ViewDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Use this method if you want to find/specify the column by its index number
                // Replace 1 with the index of the ComboBoxColumn
                if (e.ColumnIndex == 1)
                {
                    ViewDataGrid.Rows[e.RowIndex].Cells["Arrival_State"].Value =
                        ViewDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                // Use this method if you want to find/specify the column by its name
                // I prefer this method just in case the order changes
                if (ViewDataGrid.Columns[e.ColumnIndex].Name == "ComboBoxColumnName")
                {
                    ViewDataGrid.Rows[e.RowIndex].Cells["Arrival_State"].Value =
                        ViewDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

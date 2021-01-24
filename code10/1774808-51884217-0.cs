     private void Datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
            {
    TextBox quantity = e.EditingElement as TextBox;
                    DataGridColumn dgc = e.Column;
    
                    if (Datagrid.SelectedCells.Count > 0)
                    {
                        DataGridCellInfo cell = Datagrid.SelectedCells[0];
    
                        var generator = Datagrid.ItemContainerGenerator;
                        int columnIndex = cell.Column.DisplayIndex;
                        int rowIndex = generator.IndexFromContainer(generator.ContainerFromItem(cell.Item));
                        ((Item)Datagrid.Items[rowIndex]).Quantity = quantity.Text.ToString();
    
                        MessageBox.Show(quantity.Text.ToString());
                    }
    }

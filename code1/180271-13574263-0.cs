    bool? valor = false;
                    foreach (var d in DetalleFactura.Items)
                    {
                        DataGridRow row = (DataGridRow)DetalleFactura.ItemContainerGenerator.ContainerFromItem(d);
                        if (DetalleFactura.Columns[0].GetCellContent(row) is CheckBox)
                        {
                            valor = ((CheckBox)DetalleFactura.Columns[0].GetCellContent(row)).IsChecked;
    
                        }
    
                    }

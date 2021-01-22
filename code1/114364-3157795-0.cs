                    DataRowView rv = (DataRowView)r.Item;
                    foreach (DataGridColumn column in DataGrid_Standard.Columns)
                    {
                       
                        if (column.GetCellContent(r) is TextBlock)
                        {
                            TextBlock cellContent = column.GetCellContent(r) as TextBlock;
                            MessageBox.Show(cellContent.Text);
                        }
                        else if (column.GetCellContent(r) is CheckBox)
                        {
                            CheckBox chk = column.GetCellContent(r) as CheckBox;
                            MessageBox .Show (chk.IsChecked.ToString());
                        }                      
                        
                    }
                } 

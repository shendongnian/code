    public class SingleClickEditDataGridCellBehavior:Behavior<DataGridCell>
            {
                protected override void OnAttached()
                {
                    base.OnAttached();
                    AssociatedObject.PreviewMouseLeftButtonDown += DataGridCellPreviewMouseLeftButtonDown;
                }
            
                protected override void OnDetaching()
                {
                    base.OnDetaching();
                    AssociatedObject.PreviewMouseLeftButtonDown += DataGridCellPreviewMouseLeftButtonDown;
                }
            
                void DataGridCellPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                     DataGridCell cell = sender as DataGridCell;
                    if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
                    {
                        if (!cell.IsFocused)
                        {
                            cell.Focus();
                        }
                        DataGrid dataGrid = LogicalTreeWalker.FindParentOfType<DataGrid>(cell); //FindVisualParent<DataGrid>(cell);
                        if (dataGrid != null)
                        {
                            if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                            {
                                if (!cell.IsSelected)
                                    cell.IsSelected = true;
                            }
                            else
                            {
                                DataGridRow row =  LogicalTreeWalker.FindParentOfType<DataGridRow>(cell); //FindVisualParent<DataGridRow>(cell);
                                if (row != null && !row.IsSelected)
                                {
                                    row.IsSelected = true;
                                }
                            }
                        }
                    }
                }    
            }

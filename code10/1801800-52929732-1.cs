        public void DG_Part_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrentPartID != 0)
            {
                int lastId = CurrentPartID;
                EditWindow ew = new EditWindow(CurrentPartID)
                {
                    Owner = this
                };
                ew.ShowDialog();
                if (Global.invokeDataGridParts == "yes")
                {
                    // Refreshes the datagrid with an updated datatable
                    InvokeDataGridPart();
                    // Finds and selects the new index position of the modified row
                    SqlPartsSetToRow(lastId);
                    // Scrolls into view
                    dg_part.ScrollToCenterOfView(dg_part.Items[dg_part.SelectedIndex]);
                    // Highlights the row
                    Dispatcher.Invoke(DispatcherPriority.SystemIdle, new Action(() =>
                    {
                        DataGridRow row = (DataGridRow)dg_part.ItemContainerGenerator.ContainerFromIndex(dg_part.SelectedIndex);
                        row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                    ));
                    // Restores index so that you may re-select the previous selection correctly
                    DG_Part_Selection();
                }
            }
        }

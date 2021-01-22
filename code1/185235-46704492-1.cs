       private async void DgvAreas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
            {
                try
                {
                    // For any other operation except, StateChanged, do nothing
                    if (e.StateChanged != DataGridViewElementStates.Selected) return;
    
                    //Get GeoData
                    if (sender is MetroFramework.Controls.MetroGrid)
                    {
                        if ((sender as MetroFramework.Controls.MetroGrid).SelectedRows.Count > 0)
                        {
                            dgvGeoData.DataSource = null;
                            metroProgressSpinnerMain.Visible = true;
                            panelFilter.Enabled = false;
    
                            var selectedRow = (sender as MetroFramework.Controls.MetroGrid).SelectedRows[0];
                            var areaItem = (AreaItem)selectedRow.DataBoundItem;
                            var geoData = await UpdateWDataPositionItems(areaItem.MachineID, areaItem.TimeStart, areaItem.TimeEnd.Value);
    
                            if (geoData.Any())
                            {
                                BeginInvoke((Action)(() =>
                                {
                                    dgvGeoData.DataSource = geoData.OrderBy(x => x.AtTime).ToList();
                                    metroProgressSpinnerMain.Visible = false;
                                    panelFilter.Enabled = true;
                                }));
                            }
                            else
                            {
                                BeginInvoke((Action)(() =>
                                {
                                    metroProgressSpinnerMain.Visible = false;
                                    panelFilter.Enabled = true;
                                }));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }

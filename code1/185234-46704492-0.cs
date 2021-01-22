    private async void DgvStaff_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
            {
                try
                {
                    // For any other operation except, StateChanged, do nothing
                    if (e.StateChanged != DataGridViewElementStates.Selected) return;
    
                    if (sender is MetroFramework.Controls.MetroGrid)
                    {
                        if ((sender as MetroFramework.Controls.MetroGrid).SelectedRows.Count > 0)
                        {
                            dgvGeoData.DataSource = null;
                            dgvAreas.DataSource = null;
    
                            metroProgressSpinnerMain.Visible = true;
                            panelFilter.Enabled = false;
    
                            dgvAreas.RowStateChanged -= DgvAreas_RowStateChanged;
    
                            var selectedRow = (sender as MetroFramework.Controls.MetroGrid).SelectedRows[0];
                            var machineModelShortView = (MachineModelShortView)selectedRow.DataBoundItem;
    
                            var startTime = Convert.ToDateTime(dateTimePickerStart.Value.ToShortDateString());
                            var endTime = Convert.ToDateTime(metroDateTimeEnd.Value.ToShortDateString());
                            var areas = await UpdateAreaItems(machineModelShortView.MachineID, startTime, endTime);
    
                            if (areas.Any())
                            {
                                BeginInvoke((Action)(() =>
                                {
                                    dgvAreas.DataSource = areas.OrderBy(x => x.AreaID).ThenBy(x => x.TimeStart).ToList();
                                    dgvAreas.RowStateChanged += DgvAreas_RowStateChanged;
    
                                    // !!! This is how you simulate click to the FIRST ROW dgvAreas.Rows[0]
                                    DgvAreas_RowStateChanged(dgvAreas, 
                                        new DataGridViewRowStateChangedEventArgs(dgvAreas.Rows[0],  DataGridViewElementStates.Selected));
    
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

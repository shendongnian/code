                    List<string> srlist = new List<string>();
                    List<string> sdplist = new List<string>();
                    List<string> dumamountlist = new List<string>();
    
                    foreach (DataGridViewRow row in this.dgvSlsSRsList.Rows)
                    {
                        var cell = row.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
    
                        if (Convert.ToBoolean(cell.Value) == true)
                        {
                            srlist.Add(row.Cells[1].Value.ToString());
                            sdplist.Add(row.Cells[2].Value.ToString());
                            dumamountlist.Add(row.Cells[8].Value.ToString());
    
    
                        }
                        else if (cell.State == DataGridViewElementStates.Selected)
                        {
                            srlist.Add(row.Cells[1].Value.ToString());
                            sdplist.Add(row.Cells[2].Value.ToString());
                            dumamountlist.Add(row.Cells[8].Value.ToString());
                        }
                    
                    }

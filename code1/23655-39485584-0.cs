                        temp = Convert.ToDateTime(grd.Rows[e.RowIndex].Cells["dateg"].Value);
                        grd.Rows[e.RowIndex].Cells["dateg"].Value = temp.ToString("yyyy/MM/dd");
                    }
                    catch 
                    {
                        
                         MessageBox.Show("Sorry The date not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1,MessageBoxOptions .RightAlign);
                        grd.Rows[e.RowIndex].Cells["dateg"].Value = null;
                    }

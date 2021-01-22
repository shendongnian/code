    private void GridViewName_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                   //Capture index Row Event
                        int  numberRow = Convert.ToInt32(e.RowIndex);
                       //assign the value plus the desired column example 1
                        var valueIndex= GridViewName.Rows[numberRow ].Cells[1].Value;
                        MessageBox.Show("ID: " +valueIndex);
                    }

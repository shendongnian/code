     //Check checkin/out state and set to opiset
                if (dataGridView1.Rows[numberRow].Cells[5].Value.Equals(true))
                {
                    dataGridView1.Rows[numberRow].Cells[5].Value = false;
                    newHistoryRow["Action"] = "Checkout";
                    sIMSDataSet.Tables["History"].Rows.Add(newHistoryRow);
                    historyTableAdapter.Update(sIMSDataSet);
                }
                else
                {
                    dataGridView1.Rows[numberRow].Cells[5].Value = true;
                    newHistoryRow["Action"] = "Checkin";
                    sIMSDataSet.Tables["History"].Rows.Add(newHistoryRow);
                    historyTableAdapter.Update(sIMSDataSet);
                }
                //check if username cell is empty, if is empty add username if is full remove username
                if (String.IsNullOrEmpty(dataGridView1.Rows[numberRow].Cells[4].Value as string))
                {
                    dataGridView1.Rows[numberRow].Cells[4].Value = username;
                }
                else
                {
                    dataGridView1.Rows[numberRow].Cells[4].Value = "";
                }

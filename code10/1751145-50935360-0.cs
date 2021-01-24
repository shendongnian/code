        if (dataGridView1.SelectedCells.Count >0)                                         
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    att.SetEmployeeId(id = Convert.ToInt32(selectedRow.Cells["emp_id"].Value));
                    att.SetWorkDate(work_date_picker.Text);
                    att.SetExpectedTime(expected_time_picker.Text);
                    att.SetTimeIn(time_in_picker.Text);
                    Database database = new Database();
                    database.OpenConnection();
                    database.AddAttendancetable(att);
                    database.CloseConnection();
                }

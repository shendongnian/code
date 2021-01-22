                XtraMessageBox.Show("Please submit the record");
            }
            else
            {
                DialogResult dialog = XtraMessageBox.Show("Are you sure you want to remove this record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    String st = "DELETE FROM OutPatient WHERE OutPatientID =" + textEdit8.Text;
                    SqlCommand com = new SqlCommand(st, con);
                    con.Open();
                    try
                    {
                        com.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        con.Close();
                    }
                    ClearOutPatient();
                }
                else if (dialog == DialogResult.Cancel)
                {
                    ClearOutPatient();
                }

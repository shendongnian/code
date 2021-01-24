      try
                {
                    String insert_query = "INSERT INTO StReg VALUES('" + cmbMemNo.Text + "','" + txtFName.Text + "','" + txtName.Text + "','" + Gender + "','" + dtpDOB.Text + "','" + txtTelNo.Text + "','" + txtSchool.Text + "','" + txtAdNo.Text + "','" + txtMom.Text + "','" + txtMomOcc.Text + "','" + txtDad.Text + "','" + txtDadOcc.Text + "')";
                    if (Con.State == System.Data.ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Cmd = new SqlCommand(insert_query, Con);
                    Cmd.ExecuteNonQuery();
                    //Con.Close(); - move this line to finally
                    MessageBox.Show("The new Student " + txtName.Text + "( S-" + cmbMemNo.Text + " ) has successfully inserted into the system!!!", "INSERTED!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occur  :"+ ex.Message);
                }
                finally {
                    Con.Close();
                }

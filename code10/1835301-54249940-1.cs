     private void textBox1_KeyDown(object sender, KeyEventArgs e)
      {
            using (SqlConnection con = new SqlConnection(connStrng))
            {
                con.Open();
                String strSQL = "SELECT ProdName, Volume, CostPrice From tblProduct Where ProdCode=@ProdCode";
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@ProdCode", txtProdId.Text);
                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                    {
                        DA.SelectCommand = cmd;
                        if (DS.Tables.Count > 0)
                        {
                            if (DS.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row in DS.Tables[0].Rows)
                                {
                                    txtProdName.Text = row["ProdName"].ToString();
                                    txtProdVol.Text = row["Volume"].ToString();
                                    txtProdPrice.Text = row["CostPrice"].ToString();
                                }
                            }
                            else
                            {
                                txtProdName.Text = String.Empty;
                                txtProdVol.Text = String.Empty;
                                txtProdPrice.Text = String.Empty;
                                MessageBox.Show("No record found!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No record found!");
                        }
                    }
                }
            }
      }

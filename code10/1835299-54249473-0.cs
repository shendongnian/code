    private void txtProdId_TextChanged(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == Keys.Enter)
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
                        try
                        {
                            DataSet DS = new DataSet();
                            DA.Fill(DS);
                            foreach (DataRow row in DS.Tables[0].Rows)
                            {
                                txtProdName.Text = row["ProdName"].ToString();
                                txtProdVol.Text = row["Volume"].ToString();
                                txtProdPrice.Text = row["CostPrice"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

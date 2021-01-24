        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuant.Text.Length == 0)
            {
                MessageBox.Show("Quantity Field is Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Q_tity();
                con.Open();
                //  con.Close();
                if (Quantity < Convert.ToDouble(txtQuant.Text))
                {
                    string qwe = "Select MIN(Quantity/Quantifier) from Stocks where ItemID in (Select ItemID from Recipe where MenuID in (Select MenuID from Menu where ItemName ='" + txtProd.Text + "'))";
                    SqlCommand cmd = new SqlCommand(qwe, con);
                    int qty = Convert.ToInt32(cmd.ExecuteScalar()); //<--  use executescalar
                    MessageBox.Show(txtQuant.Text + " is unavailable! \n The Available Quantity of  " + txtProd.Text + " is " + qty + " only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                }
            }

    private void lbSERIES_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lbSERIES.Items.Count; i++)
            {    
                if (lbSERIES.SelectedItems.Contains(lbSERIES.Items[i]))
                {
                    chart1.Series[i + 2].Enabled = true;
                }
                else
                {
                    chart1.Series[i + 2].Enabled = false;
                }
            } // end for each item check 
        } // end selection changed

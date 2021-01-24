        private void myDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = myDGV.CurrentCell.RowIndex;
            txtDsc.Text = myDGV.Row[row].Cells["Description"].Value.ToString();
            txtQty.Text = myDGV.Row[row].Cells["Qty"].Value.ToString();
            txtUnt.Text = myDGV.Row[row].Cells["Unit"].Value.ToString();
            txtPrc.Text = myDGV.Row[row].Cells["Price"].Value.ToString();
            txtRmr.Text = myDGV.Row[row].Cells["Remarks"].Value.ToString();
        }

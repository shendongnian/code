    private void grdBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        grdBill.CurrentCell =  grdBill.Rows[grdBill.CurrentRow.Index].Cells["gBillNumber"];
    }
    private void grdBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        calcBill();
    }
    private void calcBill()
    {
        listBox1.Items.Clear();
        for (int i = 0; i < grdBill.Rows.Count - 1; i++)
        {
            if (Convert.ToBoolean(grdBill.Rows[i].Cells["gCheck"].Value) == true)
            {
                listBox1.Items.Add(grdBill.Rows[i].Cells["gBillNumber"].Value.ToString());
            }
        }
    }

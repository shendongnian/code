    private void dtGrdVwRFIDTags_DataSourceChanged(object sender, EventArgs e)
    {
        dtGrdVwRFIDTags.Refresh();
        this.dtGrdVwRFIDTags.Columns[1].Visible = false;
        foreach (DataGridViewRow row in this.dtGrdVwRFIDTags.Rows)
        {
            if (row.Cells["TagStatus"].Value != null 
                && row.Cells["TagStatus"].Value.ToString() == "Lost" 
                || row.Cells["TagStatus"].Value != null 
                && row.Cells["TagStatus"].Value.ToString() == "Damaged" 
                || row.Cells["TagStatus"].Value != null 
                && row.Cells["TagStatus"].Value.ToString() == "Discarded")
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                row.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.Ivory;
            }
        }  
        //for (int i= 0 ; i<dtGrdVwRFIDTags.Rows.Count - 1; i++)
        //{
        //    if (dtGrdVwRFIDTags.Rows[i].Cells[3].Value.ToString() == "Damaged")
        //    {
        //        dtGrdVwRFIDTags.Rows[i].Cells["TagStatus"].Style.BackColor = Color.Red;                   
        //    }
        //}
    }

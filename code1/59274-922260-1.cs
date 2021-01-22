    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView rowView = (DataRowView)e.Row.DataItem;
        for (int i = 0; i < rowView.Row.ItemArray.Length; i++)
        {
            DateTime? tmpDate = rowView[i] as DateTime?;
            if (tmpDate.HasValue)
            {
                if (tmpDate.Value.Second > 0)
                    e.Row.Cells[i].Text = tmpDate.Value.ToShortTimeString();
                else
                    e.Row.Cells[i].Text = tmpDate.Value.ToShortDateString();
            }
        }
    }

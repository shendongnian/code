    private void grdOrderItems1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (e.RowIndex > grdOrderItems.Rows.Count - 1) return;
        var row = grdOrderItems.Rows[e.RowIndex];
        TimeSpan timeOfDay = DateTime.Now - DateTime.Today;
        //It *looks like* Cells[0].Value is already a DateTime, but I'm not 100% on this
        // If I'm wrong and it's a string, its worth it to parse just that one value to a DateTime here, and still plug that DateTime value into this code instead of the Cell.
        DateTime OrderDateTime = ((DateTime)row.Cells[0].Value).Date + timeOfDay;
        var days = (DateTime.Now - OrderDateTime).TotalDays;
        if (days > 2)
        {
            row.DefaultCellStyle.BackColor = Color.Tomato;
        }
        else if (days > 1)
        {
            row.DefaultCellStyle.BackColor = Color.Yellow;
        }
        else if (days > 0)
        {
            row.DefaultCellStyle.BackColor = Color.Tan;
        }
    }

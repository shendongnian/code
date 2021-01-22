    private void dgtest_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
             dtp = new DateTimePicker();
            dgtest.Controls.Add(dtp);
            dtp.Format = DateTimePickerFormat.Short;
            Rectangle Rectangle = dgtest.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
            dtp.Location = new Point(Rectangle.X, Rectangle.Y);
            dtp.CloseUp += new EventHandler(dtp_CloseUp);
            dtp.TextChanged += new EventHandler(dtp_OnTextChange);
            dtp.Visible = true;
        }
    }
    private void dtp_OnTextChange(object sender, EventArgs e)
    {
        dgtest.CurrentCell.Value = dtp.Text.ToString();
    }
    void dtp_CloseUp(object sender, EventArgs e)
    { 
        dtp.Visible = false;
    }

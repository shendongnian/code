    private void Form1_Load(object sender, EventArgs e)
    {
        using (DataTable dt = GetData()) {
            listBox1.DisplayMember = dt.Columns[0].ColumnName;
            listBox1.DataSource = dt;
        }
    }
    private DataTable GetData()
    {
        using (OleDbConnection myConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString))
        using (OleDbCommand myQuery = new OleDbCommand("SELECT empName FROM empTable", myConn))
        using (OleDbDataAdapter adapter = new OleDbDataAdapter(myQuery)) {
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
    private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        var lbx = sender as ListBox;
        bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
        using (SolidBrush bgBrush = new SolidBrush(isItemSelected ? Color.FromArgb(64, 64, 64) : lbx.BackColor))
        using (SolidBrush itemBrush = isItemSelected ? new SolidBrush(lbx.ForeColor) : new SolidBrush(Color.LightGray)) {
            string itemText = lbx.GetItemText(lbx.Items[e.Index]);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.FillRectangle(bgBrush, e.Bounds);
            e.Graphics.DrawString(itemText, e.Font, itemBrush, e.Bounds);
        }
        e.DrawFocusRectangle();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        using (DataTable dt = GetData()) {
            listBox1.DisplayMember = dt.Columns[0].ColumnName;
            listBox1.DataSource = dt.DefaultView;
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
        e.DrawBackground();
        bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
        using (SolidBrush backgroundColorBrush = new SolidBrush(isItemSelected ? Color.FromArgb(64, 64, 64) : Color.FromArgb(0, 64, 64, 64)))
        using (SolidBrush itemTextColorBrush = isItemSelected ? new SolidBrush(Color.White) : new SolidBrush(Color.LightGray))
        {
            string itemText = listBox1.GetItemText(listBox1.Items[e.Index]);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.FillRectangle(backgroundColorBrush, e.Bounds);
            e.Graphics.DrawString(itemText, e.Font, itemTextColorBrush, e.Bounds);
        }
        e.DrawFocusRectangle();
    }

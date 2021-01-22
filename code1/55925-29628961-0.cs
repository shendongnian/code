    private string[] _colLst = columNameArray;
    private void AddCheckBoxGridViewHeader()
    {
        for (int ndx = 0; ndx < _colLst.Length; ndx++)
        {
            var rect = dtgv1.GetCellDisplayRectangle(ndx, -1, true);
            var x = rect.X + (rect.Width * 4 / 5);
            var y = 3;
            Rectangle nrect = new Rectangle(x, y, rect.Width, rect.Height);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.BackColor = Color.Transparent;
            checkboxHeader.Name = "checkboxHeader" + ndx;
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = nrect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dtgv1.Controls.Add(checkboxHeader);
        }
    }
    private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox headerBox = ((CheckBox)dtgv1.Controls.Find("checkboxHeader", true)[0]);
        var headerBox = (CheckBox)sender;
        var b = headerBox.Checked;
        var c = int.Parse(headerBox.Name.Replace("checkboxHeader", ""));
        for (int i = 0; i < dtgv1.RowCount; i++)
        {
            dtgv1.Rows[i].Cells[c].Style = new DataGridViewCellStyle(); 
            dtgv1.Rows[i].Cells[c].Style.BackColor = (b)? Color.Salmon : Color.White;
        }
    }

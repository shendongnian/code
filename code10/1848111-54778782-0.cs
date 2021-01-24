    dtData.Columns.Add(new DataColumn("id", typeof(System.Int32)));
    dtData.Columns.Add(new DataColumn("name", typeof(System.String)));
    dtData.Columns.Add(new DataColumn("selected", typeof(bool)));
    string[] vList = new string[] { "A", "B", "C" };
    DataRow dRow = null;
    for (int index = 0; index < vList.Length; index++)
    {
        dRow = dtData.NewRow();
        dtData.Rows.Add(dRow);
        dRow[0] = index;
        dRow[1] = vList[index];
        dRow[2] = false;
    }
    //don't miss binding "defaultView"
    this.listBox1.DataSource = dtData.DefaultView;
    this.listBox1.DisplayMember = "name";
    this.listBox1.ValueMember = "selected";
    dtData.Rows[0][2] = true;
    //this will allow filter item that you don't need to show.
    dtData.DefaultView.RowFilter = string.Format("selected='{0}'", bool.FalseString);

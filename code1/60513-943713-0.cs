        // define the columns
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Foo", typeof(int));
        table.Columns.Add("Bar", typeof(string));
        table.Columns.Add("Audit", typeof(DateTime));
        // add some data; the one we want is row 2
        table.Rows.Add(1,14,"abc", DateTime.MinValue);
        DataRow row = table.Rows.Add(2,13,"def", DateTime.MinValue);
        table.Rows.Add(3,24,"ghi", DateTime.MinValue);
        // get a DataRowView that matches our DataRow
        DataView view = new DataView(row.Table);
        DataRowView rowView = null;
        foreach(DataRowView tmp in view) {
            if(tmp.Row == row) {
                rowView = tmp;
                break;
            }
        }
        // display it
        Application.EnableVisualStyles();
        Application.Run(new Form {Controls = {
            new PropertyGrid { Dock = DockStyle.Fill,
                SelectedObject = rowView }}});

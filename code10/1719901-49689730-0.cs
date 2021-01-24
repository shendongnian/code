    //Create DataTable having desired columns
    var columnsXml = XDocument.Load(@"d:\columns.xml");
    var columns = columnsXml.Root.Element("Columns").Elements()
        .Select(x => new DataColumn(x.Attribute("Name").Value));
    var dt = new DataTable();
    dt.Columns.AddRange(columns.ToArray());
    //Then load data to DataTable
    //here is some dummy data
    dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
    dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
    //Set DataSource of DataGridView
    this.dataGridView1.DataSource = dt;

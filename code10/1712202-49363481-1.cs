    public class DataGridRow
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
    }
...
    var row = new DataGridRow{ Col1 = "Column1", Col2 = "Column2" };
    dataGrid.Items.Add(row);

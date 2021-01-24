    public class Item
    {
        public string Data { get; set; }
        public string Sing { get; set; }
        public string Avtor { get; set; }
        // and so on ...
    }
    // Save data into private class member
    private List<Item> _loadedData = new List<Item>();
    private void button1_Click_1(object sender, EventArgs e)
    {
        using (var stream  = new FileStream("zapis.dat", FileMode.Open))
        using (var reader = new BinaryReader(stream))
        {
            var data = new List<Item>();
            while (stream.Position < stream.length)
            {
                var item = new Item
                {
                    Data = reader.ReadString(),
                    Sing = reader.ReadString(),
                    Avtor = reader.ReadString()
                };
                data.Add(item)
            }
            // update private member with newly loaded data
            _loadedData = data;
        }
        // Bind loaded data to the DataGridView
        datagridview1.DataSource = _loadedData;
    }

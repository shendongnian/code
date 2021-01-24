    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    private async void Form1_Load(object sender, EventArgs e)
    {
        // Define list
        var list = new List<Product>();
        // Fill data
        list.Add(new Product { Name = "Product 1", Price = 100 });
        list.Add(new Product { Name = "Product 2", Price = 200 });
        // Set data source of data grid view
        var bs = new BindingSource();
        bs.DataSource = list;
        this.dataGridView1.DataSource = bs;
        // Automatically update text box, by SUM of price
        textBox1.Text = $"{list.Sum(x => x.Price):F2}";
        bs.ListChanged += (obj, args) =>
            textBox1.Text = $"{list.Sum(x => x.Price):F2}";
    }

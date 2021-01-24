    public partial class Form1 : Form
    {
        private class Item
        {
            public decimal fieldA = 0;
            public string fieldB = "";
            public override string ToString()
            {
                return $"{fieldA}{fieldB}";
            }
        }
        List<Item> items = new List<Item>()
        {
            new Item{fieldA = 3.8M,fieldB = "klsd"},
            new Item{fieldA = 84.6M,fieldB = "jio"},
            new Item{fieldA = 64.97M,fieldB = "gjidf"}
        };
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = items.OrderBy(x => x.fieldA).ToList();
        }
    }

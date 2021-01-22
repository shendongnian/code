    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            List<Item> items = new List<Item>();
    
            items.Add(new Item("item 1"));
            items.Add(new Item("item 2"));
            items.Add(new Item("item 3"));
            items.Add(new Item("item 4"));
    
    
            dataGridView1.DataSource = items;
        }
    }
    class Item
    {
        public string ItemName { get; set; }
        public Item(string name)
        {
            ItemName = name;
        }
    
    }

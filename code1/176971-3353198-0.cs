    public partial class Form1 : Form
    {
        List<Item> items = new List<Item>
        {
            new Item { Value = "One" },
            new Item { Value = "Two" },
            new Item { Value = "Three" },
        };
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = items;
            listBox1.DisplayMember = "Value";
        }
    }
    public class Item
    {
        public string Value { get; set; }
    }

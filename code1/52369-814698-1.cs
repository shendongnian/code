    public partial class Form1 : Form
    {
        List<string> _items = new List<string>();
        public Form1()
        {
            InitializeComponent();
            _items.Add("One");
            _items.Add("Two");
            _items.Add("Three");
            listBox1.DataSource = _items;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // The Add button was clicked.
            _items.Add("New item " + DateTime.Now.Second);
            // Change the DataSource.
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // The Remove button was clicked.
            int selectedIndex = listBox1.SelectedIndex;
            try
            {
                // Remove the item in the List.
                _items.RemoveAt(selectedIndex);
            }
            catch
            {
            }
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
        }
    }

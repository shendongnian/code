    public partial class Form1 : Form
    {
        BindingList<string> items = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            this.listBox1.DataSource = items;
        }
    
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.deleteButton.Enabled = (this.listBox1.SelectedIndex != -1);
        }
    
        private void addButton_Click(object sender, EventArgs e)
        {
            this.items.Add($"item {this.items.Count + 1}");
            this.listBox1.SelectedIndex = -1;
            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
        }
    
        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.items.RemoveAt(this.listBox1.SelectedIndex);
        }
    }

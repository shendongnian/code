    public class Form1 : Form
    {
        private bool itemsLoading;
        public Form1()
        {
            InitializeComponent();
            LoadListItems();
        }
        private void LoadListItems()
        {
            itemsLoading = true;
            try
            {
                listBox1.DataSource = ...
                listBox1.SelectedItem = ...
            }
            finally
            {
                itemsLoading = false;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsLoading)
                return;
            // Handle the changed event here...
        }
    }

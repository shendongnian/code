    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AddComboBoxItems(comboBox1, 10, "Sunday");
            AddComboBoxItems(comboBox1, 20, "Tuesday");
            AddComboBoxItems(comboBox1, 100, "Friday");
        }
        IDictionary<int, string> comboSource = new Dictionary<int, string>();
        public void AddComboBoxItems(ComboBox cmbbox, int itemvalue, string itemstring)
        {
            comboSource.Add(new KeyValuePair<int, string>(itemvalue, itemstring));
            cmbbox.DataSource = new BindingSource(comboSource, null);
            cmbbox.DisplayMember = "Value";
            cmbbox.ValueMember = "Key";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 20;
            if (comboBox1.Items.Contains(x))
            { comboBox1.SelectedValue = x; }
            else
            {
                comboBox1.Text = x.ToString();
            }
        }  
    }

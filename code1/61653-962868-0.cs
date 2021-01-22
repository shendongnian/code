        private Dictionary<int, ComboBox> comboBoxes;
        public Form1()
        {
            InitializeComponent();
            this.comboBoxes = new Dictionary<int, ComboBox>();
            this.dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var cb = e.Control as ComboBox;
            if (!(this.comboBoxes.ContainsKey(this.dataGridView1.CurrentRow.Index)))
            {
                this.comboBoxes.Add(this.dataGridView1.CurrentRow.Index, cb);
            }
        }

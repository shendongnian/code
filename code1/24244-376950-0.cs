        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.cboCollection != null)
                this.comboBox1.Items.AddRange(Settings.Default.cboCollection.ToArray());
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArrayList arraylist = new ArrayList(this.comboBox1.Items);
            Settings.Default.cboCollection = arraylist;
            Settings.Default.Save();
        }
        //A button to add items to the ComboBox
        private int i;
        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add(i++);
        }

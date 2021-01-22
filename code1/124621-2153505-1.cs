        private void Form1_Load(object sender, EventArgs e)
        {
            this.employeesTableAdapter.Fill(this.dS.Employees);
        }
        private int _i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            ComboBox combo = new ComboBox();
            combo.DataSource = this.employeesBindingSource;
            combo.DisplayMember = this.dS.Tables[0].Columns[++_i].ColumnName;
            combo.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + comboBox1.Height * _i);
            this.Controls.Add(combo);
        }

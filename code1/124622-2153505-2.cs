      private int _i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataS = dS.Clone();
            this.employeesTableAdapter.Fill((DS.EmployeesDataTable)dataS.Tables[0]);
            BindingSource bindSource = new BindingSource(dataS, "Employees");
            ComboBox combo = new ComboBox();
            combo.Name = this.dS.Tables[0].Columns[0].ColumnName + (++_i).ToString();
            combo.DataSource = bindSource;
            combo.DisplayMember =  this.dS.Tables[0].Columns[1].ColumnName; //This column is the Name of Employee
            combo.Location = new Point(button1.Location.X, button1.Location.Y + combo.Height * _i);
            combo.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            this.Controls.Add(combo);
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox && ctrl != sender && ctrl.Enabled)
                {
                    ((BindingSource)((ComboBox)ctrl).DataSource).RemoveAt(((ComboBox)sender).SelectedIndex);
                }
            }
            ((ComboBox)sender).Enabled = false;
        }

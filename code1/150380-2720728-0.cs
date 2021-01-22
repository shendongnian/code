            private void Form1_Load(object sender, EventArgs e)
            {
                AComboBox.Items.Add("1");
                AComboBox.Items.Add("2");
                AComboBox.Items.Add("3");
                AComboBox.Items.Add("4");
                AComboBox.Items.Add("5");
                AComboBox.Items.Add("6");
            }
    
            private void AComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                BComboBox.Items.Clear();
    
                //* One way.
                foreach (object obj in AComboBox.Items.Cast<object>().Where(obj => !obj.Equals(AComboBox.Text)))
                {
                    BComboBox.Items.Add(obj);
                }
    
                //* Another way (if possible duplicates in A).
                for (int i = 0; i < AComboBox.Items.Count; ++i)
                {
                    if (i != AComboBox.SelectedIndex)
                        BComboBox.Items.Add(AComboBox.Items[i]);
                }
            }

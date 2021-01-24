                for (int i = 0;i <comboBox1.Items.Count; i++)
                {
                    comboBox1.SelectedIndex = i;
                    if ((string)(comboBox1.SelectedValue) == Convert.ToString(rowSelected[14]))
                    {
                        index = i;
                    }
                }
                comboBox1.SelectedIndex = index;

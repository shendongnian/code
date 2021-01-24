          if (contactIDComboBox1.SelectedIndex!=-1 && contactIDComboBox1.SelectedValue!=null)
           {
           
                if (!contactPositionListBox1.Items.Contains(contactIDComboBox1.Text))
                {
                    contactPositionListBox1.Items.Add(contactIDComboBox1.Text);
                    contactIDList.Add((int)contactIDComboBox1.SelectedValue);
                   
                    
                }
                
            }
        }

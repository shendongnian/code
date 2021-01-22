     private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataRowView selected = listBox1.SelectedItem as DataRowView;
            if (selected != null)
            {
                string item = selected["title"].ToString();
                listBox2.Items.Add(item);
            }
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            string selected = listBox2.SelectedItem as string;
            int oldIndex = listBox2.SelectedIndex;
            int newIndex = oldIndex;
            if (!string.IsNullOrEmpty(selected) && listBox2.Items.Count > 1 && oldIndex > 0)
            {
                listBox2.SuspendLayout(); 
                listBox2.Items.RemoveAt(oldIndex);
                newIndex = oldIndex - 1;
                listBox2.Items.Insert(newIndex, selected);
                listBox2.SelectedIndex = newIndex;
                listBox2.ResumeLayout();
              
            }
        }

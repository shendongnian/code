        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            string item = listBox1.SelectedItem.ToString();
            if (!selectedItems.Contains(item))
            {
                selectedItems.Add(item);
            }
        }

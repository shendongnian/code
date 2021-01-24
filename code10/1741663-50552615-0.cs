    private void button1_Click_3(object sender, EventArgs e)
    {
         if (listBox1.Items.Count >= 1)
              {
                   if (listBox1.SelectedValue != null)
                   {
                        var items = listBox1.Items;
                        items.Remove(listBox1.SelectedItem);
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(items);
                   }
              }
         else
         {
              System.Windows.Forms.MessageBox.Show("No ITEMS Found");
         }
    }

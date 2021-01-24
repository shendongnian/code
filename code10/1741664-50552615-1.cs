    private void button1_Click_3(object sender, EventArgs e)
    {
         if (listBox1.Items.Count >= 1)
              {
                   if (listBox1.SelectedValue != null)
                   {
                        var items = (List<YourType>)listBox1.DataSource;
                        var item = (YourType)listBox1.SelectedValue;
                        listBox1.DataSource = null;
                        listBox1.Items.Clear();
                        items.Remove(item);
                        listBox1.DataSource = items;
                   }
              }
         else
         {
              System.Windows.Forms.MessageBox.Show("No ITEMS Found");
         }
    }

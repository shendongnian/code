    private void button1_Click(object sender, EventArgs e)
    {      
                foreach (var item in ChGetQtnNumber.CheckedItems)
                {
                    MessageBox.Show(item.ToString());
                }
    }

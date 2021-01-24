    private void addItem_Click(object sender, EventArgs e)
    {
            var listOfItems = displayBurgerBox.Items.Cast<String>().ToArray();
            MessageBox.Show(string.Join($"{Environment.NewLine}",listOfItems));
            textBox1.Text = string.Join($"{Environment.NewLine}", listOfItems);
     }

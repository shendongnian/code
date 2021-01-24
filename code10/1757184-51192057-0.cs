    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string stringToSplit = listBox1.SelectedItem.ToString();
        var splitString =  stringToSplit.Split(',');
        textBox1.Text = splitString[0];
        textBox2.Text = splitString.Length > 1 ? splitString[1] : string.Empty;
    }

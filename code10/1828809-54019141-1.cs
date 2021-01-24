    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var filtered = _loadedData.Select(item => item);
        if (string.IsNullOrEmpty(textBox1.Text) == false)
        {
            filtered = filtered.Where(item => item.Avtor == textBox1.Text);
        }
     
        datagridview1.DataSource = filtered.ToList();
    }

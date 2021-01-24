    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            comboBox1.DataSource = dt; //your origin data
    
        }
        else
        {
            var newTable = dt.AsEnumerable()
          .Where(x => x.Field<string>("VALUE").ToUpper().Contains(textBox1.Text.ToUpper()))
          .CopyToDataTable();
    
            comboBox1.DataSource = newTable;
    
        }
    }

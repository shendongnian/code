    void createSearchResultHeader()
    {
        foreach(var prop in typeof(DB.Message).GetProperties())
        {
            var display =
               typeof(DB.Message)
               .GetProperty(prop.Name)
               .GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), inherit: false)
               .FirstOrDefault() as System.ComponentModel.DisplayNameAttribute;
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = display.DisplayName;
            col.DataPropertyName = prop.Name; // Add this
            dataGridView1.Columns.Add(col);
        }
    }

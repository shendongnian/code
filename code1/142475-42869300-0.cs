    private void PopulateData()
    {            
       while (condition) //Columns[0] is where your ComboBoxColumn index
          (dataGridView1.Columns[0] as DataGridViewComboBoxColumn)
          .Items.Add("Item 1");
    }

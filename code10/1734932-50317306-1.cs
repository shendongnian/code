    private void button1_Click(object sender, EventArgs e)
    {   
       // To Get The Selected Row
       var  dr =  dataGridView1.SelectedRows[0];
       // The Cells Property is going to return DataGridViewCellCollection a list again
       // Basically the columns so the first one will be the first column and so on
       string item1 = dr.Cells[0].Value.ToString();
       string item2 = dr.Cells[1].Value.ToString();
       string item3 = dr.Cells[2].Value.ToString();
    }

    DateTime d1;
    DateTime d2;
    
    if (!DateTime.TryParse(dataGridView1.Rows[0].Cells["DueDate"].Value, out d1) 
        || !DateTime.TryParse(dataGridView1.Rows[0].Cells["PaymentDate"].Value, out d2))
    {
        MessageBox.Show("Invalid Period");
        return;
    }
            
    if (d1 <= d2)
    {
        MessageBox.Show("Late Payment");
    }

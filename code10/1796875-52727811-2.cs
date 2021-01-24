    var dueDate = dataGridView1.Rows[0].Cells["DueDate"].Value != null
        ? dataGridView1.Rows[0].Cells["DueDate"].Value.ToString()
        : string.Empty;
    var paymentDate = dataGridView1.Rows[0].Cells["PaymentDate"].Value != null
        ? dataGridView1.Rows[0].Cells["PaymentDate"].Value.ToString()
        : string.Empty;
        
    DateTime d1;
    DateTime d2;
    
    if (!DateTime.TryParse(dueDate, out d1) || DateTime.TryParse(paymentDate, out d2))
    {
        MessageBox.Show("Invalid Period"); //Here you can show a message or simply bypass
        return;
    }
            
    if (d1 <= d2)
    {
        MessageBox.Show("Late Payment");
    }

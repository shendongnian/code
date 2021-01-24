     private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Expenses
                         .Where(x => x.Period.Day == dateTimePicker1.Value.Day && 
                                     x.Period.Month == dateTimePicker1.Value.Month &&  
                                     x.Period.Year == dateTimePicker1.Value.Year)
                         .ToList();    
           //OR
    
           dataGridView1.DataSource = Expenses
                         .Where(x => x.Period.Date == dateTimePicker1.Value.Date)
                         .ToList();
        }

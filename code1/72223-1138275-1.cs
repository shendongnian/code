    public MyClass()
    {
        // Create a new DateTimePicker
        DateTimePicker dateTimePicker1 = new DateTimePicker();
        Controls.Add(dateTimePicker1);
        MessageBox.Show(dateTimePicker1.Value.ToString());
        
        dateTimePicker1.Value = DateTime.Now.AddDays(1);
        MessageBox.Show(dateTimePicker1.Value.ToString());
     } 

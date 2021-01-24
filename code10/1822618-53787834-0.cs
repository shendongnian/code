    Queue<string> EmployeeMessages = new Queue<string>();
    private void OnLogin()
    {
        var reader = GetReader();
    
        while (reader.Read())
        {
            EmployeeMessages.Enqueue(reader["Message"].ToString());
        }
    
        if (EmployeeMessages.Count > 0)
        {
            label1.Text = EmployeeMessages.Dequeue();
        }
    }
    
    
    private void button1_Click(object sender, EventArgs e)
    {
        if (EmployeeMessages.Count > 0)
        {
            label1.Text = EmployeeMessages.Dequeue();
        }
    }

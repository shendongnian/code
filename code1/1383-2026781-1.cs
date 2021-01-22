    List<Message> messages = new List<Message>();
    foreach (row in DataTable.Rows)
    {
        var message = new Message
        {
            Id = Convert.ToInt32(row["MessageId"]),
            Text = Convert.ToInt32(row["MessageText"]),
            Date = Convert.ToInt32(row["MessageDate"])
        };
    
        messages.Add(message);
    }

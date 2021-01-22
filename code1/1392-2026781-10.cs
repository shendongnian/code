    List<Message> messages = new List<Message>();
    foreach (row in DataTable.Rows)
    {
        var message = new Message
        {
            Id = Convert.ToInt32(row["MessageId"]),
            Text = Convert.ToString(row["MessageText"]),
            Date = Convert.ToDateTime(row["MessageDate"])
        };
    
        messages.Add(message);
    }

     [HttpPost]
        public Message Post([FromBody] Message message)
        {
               
        var msg = new Message { Owner = message.Owner, Text = message.Text };
        db.Messages.AddAsync(msg);
        db.SaveChangesAsync();
        
        return message;
       
    }

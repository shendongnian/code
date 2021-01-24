    graphClient
      .Me
      .Messages["itemID"]
      .Request()
      .UpdateAsync(new Message(){ IsRead = true });
      

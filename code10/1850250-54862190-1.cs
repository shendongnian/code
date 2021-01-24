    MessageDto dto = JsonConvert.DeserializeObject<MessageDto>(jsonData);
    
    if (dto != null) {
        MyMessage message = new MyMessage();
        message.SampleNumber = dto.SampleNumber;
        message.Status = dto.Status;
        message.HasPossibleDuplicate = dto.HasPossibleDuplicate;
        message.ControlType = dto.ControlType;
    
        using (var transaction = myContext.Database.BeginTransaction())
         {
           myContext.MyMessage.Add(message);//error comes here
           myContext.SaveChanges();
           transaction.Commit();
         }
    }

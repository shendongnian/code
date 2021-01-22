    MyDataContext dc = new MyDataContext();
    
    Message msg = dc.Messages.Single(m => m.Id == 1);
    Message attachingMsg = new Message();
    attachingMsg.Id = msg.Id;
    
    dc.Messages.Attach(attachingMsg);
          
    attachingMsg.MessageSubject = msg.MessageSubject + " is now changed"; // changed
    attachingMsg.MessageBody = msg.MessageBody; // not changed
    dc.SubmitChanges();

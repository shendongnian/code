    Messages messages = queue.GetAllMessages();
    foreach(Message m in messages)
    {
      String message = m.Body;
      message.Formatter = new System.Messaging.XmlMessageFormatter(new String[] 
        { "System.String,mscorlib" });
      //do something with string
    }

    Messages messages = queue.GetAllMessages();
    foreach(Message m in messages)
    {
      m.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
      String message = m.Body;
      
      //do something with string
    }

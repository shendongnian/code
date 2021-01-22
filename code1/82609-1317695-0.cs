    using System.Messaging;
    
    ...
    
    
    MessageQueue queue = new MessageQueue(".\\Private$\\yourqueue");
    queue.Formatter = new BinaryMessageFormatter();
    
    Message m = new Message();
    m.Body = "your serialisable object or just plain string";
    
    queue.Send(m);
    
    
    // on the other side
    
    MessageQueue queue = new MessageQueue(".\\Private$\\yourqueue");
    queue.Formatter = new BinaryMessageFormatter();
    
    Message m = queue.Receive();
    
    string s = m.Body as string;
    
    // s contains that string now

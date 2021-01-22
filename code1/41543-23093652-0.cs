    static readonly XmlMessageFormatter f = new XmlMessageFormatter(new Type[] { typeof(String) });
    
    private void Client()
    {
        var messageQueue = new MessageQueue(@".\Private$\SomeTestName");
        foreach (Message message in messageQueue.GetAllMessages())
        {
            message.Formatter = f;
            Console.WriteLine(message.Body);
        }
        messageQueue.Purge();
    }

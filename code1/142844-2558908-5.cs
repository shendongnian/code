    private void MyFunction()
    {
        StringBuilder myMessage = "Just a message";
        ManipulateMessage(myMessage);
        Console.WriteLine(myMessage.ToString());
    }
    private void ManipulateMessage(StringBuilder message)
    {
        message.Insert(0, DateTime.Now + "   ");
    }

    private void MyFunction()
    {
        string myMessage = "Just a message";
        ManipulateMessage(myMessage);
        Console.WriteLine(myMessage);
    }
    private void ManipulateMessage(string message)
    {
        message = DateTime.Now + "   " + message;
    }
    

    private void MyFunction()
    {
        string myMessage = "Just a message";
        ManipulateMessage(ref myMessage);
        Console.WriteLine(myMessage);
    }
    private void ManipulateMessage(ref string message)
    {
        message = DateTime.Now + "   " + message;
    }

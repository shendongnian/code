    private void MyFunction()
    {
        string myMessage = "Just a message";
        myMessage = ManipulateMessage(myMessage);
        Console.WriteLine(myMessage);
    }
    private string ManipulateMessage(string message)
    {
        return DateTime.Now + "   " + message;
    }
    

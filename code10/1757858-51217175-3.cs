    void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
   
    Action<string> x = ShowMessage;
    x("Hello world");  //Displays "Hello world"

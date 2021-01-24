    void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
   
    Action<string> a = ShowMessage;
    a("Hello world");  //Displays "Hello world"

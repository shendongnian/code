    client.UserName = "username@gmail.com";
    client.Password = "[insert password here]";
    client.ServerName = "pop.gmail.com";
    client.AuthenticateMode = Pop3AuthenticateMode.Pop;
    client.Ssl = true; // NOTICE: in your example code you have false here
    client.Port = 995;
    client.Authenticate();
    var messageList = client.ExecuteList();
    Console.WriteLine("# Messages: {0}", messageList.Count);

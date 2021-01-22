    Using client As New Pop3Client
        client.UserName = "username@gmail.com"
        client.Password = "[insert password here]"
        client.ServerName = "pop.gmail.com"
        client.AuthenticateMode = Pop3AuthenticateMode.Pop
        client.Ssl = True ' NOTICE: in your example code you have False here '
        client.Port = 995
        client.Authenticate()
        Dim messageList = client.ExecuteList()
        Console.WriteLine("# Messages: {0}", messageList.Count)
    End Using

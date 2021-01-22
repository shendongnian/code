    Sftp client = new Sftp();
    client.CommandSent += new SftpCommandSentEventHandler(client_CommandSent);
    client.ResponseRead += new SftpResponseReadEventHandler(client_ResponseRead);
    client.Connect("sftp.example.org");
    
    //... 
    private void client_CommandSent(object sender, SftpCommandSentEventArgs e)
    {
        Console.WriteLine("Command: {0}", e.Command);
    }
    
    private void client_ResponseRead(object sender, SftpResponseReadEventArgs e)
    {
        Console.WriteLine("Response: {0}", e.Response);
    }

    private void ExecuteSingleCommand(object sender, RoutedEventArgs e)
    {
        string sshCommand = "hostname";
        string returnedResults = "localhost";
        var element = new CommandGridItems() { Delete = false, Command = sshCommand, Response = returnedResults, Results = "desc1" }
        items.Add(element);
    }

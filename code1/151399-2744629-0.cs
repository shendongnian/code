     void FireCommand()
     {
        var routedCommand = Command as RoutedCommand;
        if (routedCommand != null)
        {
           routedCommand.Execute(CommandParameter, CommandTarget);
        }
        else if (Command != null)
        {
           Command.Execute(CommandParameter);
        }
     }

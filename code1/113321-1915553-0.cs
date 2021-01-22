    DbCommand CreateCommand(string commandText) {
        var newCommand = connection.CreateCommand();
        newCommand.CommandText = commandText; // what if this throws?
        return newCommand;
    }
    void UseCommand() {
        using(var cmd = CreateCommand("my query goes here")) {
            // consume the command
        }
    }

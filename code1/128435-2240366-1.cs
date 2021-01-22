    class ServerCommand : ExeCommand
    {
        public new static object CommandHandler
        {
            get { return ExeCommand.CommandHandler; }
        }
    }

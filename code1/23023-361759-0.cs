    class CommandBuilder
    {
      private List<ICommand> _commands = new List<ICommand>();
    
      public CommandBuilder Position(double x, double y)
      {
        _commands.Add(new PositionCommand(x,y))
        return this;
      }
    
      ...
    }

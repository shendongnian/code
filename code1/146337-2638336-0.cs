    public interface ICommandBuilder
    {
        bool CanParse(string input);
        ICommand Build(string input);
    }
    public interface ICommandBuilder<TCommand> : ICommandBuilder 
        where TCommand : ICommand
    {
        TCommand Build(string input);
    }

    public interface ICommandFactory
    {
        ICommand Build(string input);
    }
    public class CommandFactory
    {
        public ICommand Build(string input)
        {
            var builder = container.ResolveAll(typeof(ICommandBuilder))
                .Where(x => x.CanParse(input));
            return builder.Build(input);
        }
    }

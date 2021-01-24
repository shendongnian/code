    public interface ICommand
    {
    }
    
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
    
    public class SomeWorkProcessCommand : ICommand
    {
    }
    
    public class SomeWorkProcessCommandHandler : ICommandHandler<SomeWorkProcessCommand>
    {
        public void Handle(SomeWorkProcessCommand command)
        {
            Console.WriteLine("Some work Process Command Handler ");
        }
    }
    
    public class Manager<TCommandHandler, TCommand>
        where TCommandHandler : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly TCommandHandler handler;
    
        public Manager(TCommandHandler handler)
        {
            this.handler = handler;
        }
    
        public void Execute(TCommand command)
        {
            handler.Handle(command);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
    
            var someWorkProcessCommandHandler = new SomeWorkProcessCommandHandler();
            someWorkProcessCommandHandler.Handle(new SomeWorkProcessCommand());// This line works fine if the below code is not present
    
            var manager = new Manager<SomeWorkProcessCommandHandler, SomeWorkProcessCommand>(someWorkProcessCommandHandler);  //Works now
            manager.Execute(new SomeWorkProcessCommand());
    
            Console.ReadKey();
        }
    }

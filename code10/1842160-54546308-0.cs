    public class Manager<TCommand> where TCommand : ICommand
	{
		private readonly ICommandHandler<TCommand> handler;
		public Manager(ICommandHandler<TCommand> handler)
		{
			this.handler = handler;
		}
		public void Execute(TCommand command)
		{
			handler.Handle(command);
		}
	}

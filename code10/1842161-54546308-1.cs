    public static class ManagerFactory
	{
		public static Manager<TCommand> Create<TCommand>(ICommandHandler<TCommand> handler)
			where TCommand : ICommand => new Manager<TCommand>(handler);
	}

    private ICommand forwardCommand;
		public ICommand ForwardCommand
		{
			get
			{
				if (forwardCommand == null)
					forwardCommand = new RelayCommand<string>(
						delegate(string param)
						{
							Messenger.Default.Send<CommandContext>(GetForwardCommandContext(param),
								ViewModelBaseMessages.ContextCommand );
						},
						delegate(string param)
						{
							return CanForwardCommand(param);
						});
				return forwardCommand;
			}
		}

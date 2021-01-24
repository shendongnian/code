		public MainViewModel() 
		{
			ButtonCommand = new RelayCommand(ExecuteButtonCommand, CanExecuteButtonCommand);
		}
		
		public RelayCommand ButtonCommand { get; private set; }
		
		public void Load()
        {
			//Example load logic
			InvalidateCommands();
		}
		
		private void InvalidateCommands()
        {
            ButtonCommand.RaiseCanExecuteChanged();
        }
			
		private void ExecuteButtonCommand(object message)
		{
			//Some method to fill the corresponding textfield
		}
		private bool CanExecuteButtonCommand(object message)
		{
			return true;
		}
	}

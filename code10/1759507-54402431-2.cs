    public class AsyncDelegateCommand : DelegateCommand
    {
        private Func<Task> executeAction;
        public AsyncDelegateCommand(Func<Task> executeAction) : base(async () => { await executeAction(); })
        {
            this.executeAction =  executeAction;
        }
        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    IsActive = true;
                    await executeAction();
                }
                finally
                {
                    IsActive = false;
                }
            }
            RaiseCanExecuteChanged();
        }
    }

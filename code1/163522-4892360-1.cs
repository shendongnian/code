        public class MyCustomCommand : ICanExecuteChanged
        {
            public void Execute(object parameter)
            {
                // Execute the command
            }
            public bool CanExecute(object parameter)
            {
                Debug.WriteLine("Parameter changed to {0}!", parameter);
                return parameter != null;
            }
            public event EventHandler CanExecuteChanged;
            public void RaiseCanExecuteChanged()
            {
                EventHandler temp = this.CanExecuteChanged;
                if (temp != null)
                {
                    temp(this, EventArgs.Empty);
                }
            }
        }

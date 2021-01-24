    public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
	
    public class CommandHandler : ICommand
        {
            public event EventHandler CanExecuteChanged { add { } remove { } }
    
            private Action<object> action;
            private bool canExecute;
    
            public CommandHandler(Action<object> action, bool canExecute)
            {
                this.action = action;
                this.canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return canExecute;
            }
    
            public void Execute(object parameter)
            {
                action(parameter);
            }
        }
	

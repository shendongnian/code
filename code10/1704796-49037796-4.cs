    public class ExecuteCommand : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(ExecuteCommand));
        public ICommand Command
        {
            get
            {
                return GetValue(CommandProperty) as ICommand;
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
    
        protected override void Invoke(object parameter)
        {
            if (Command != null)
            {
                if (Command.CanExecute(parameter))
                {
                    Command.Execute(parameter);
                }
            }
        }
    }
    
    public class EventCommand : ICommand
    {
        private Action<object> func;
    
        public EventCommand(Action<object> func)
        {
            this.func = func;
        }
    
        public bool CanExecute(object parameter)
        {
            //Use your logic here when required
            return true;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
            if (func != null)
            {
                func(parameter);
            }
        }
    }

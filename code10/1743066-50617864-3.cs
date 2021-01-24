    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    
        public static Command Pause(MediaElement element)
        {
            //element.Pause();
            return new Command(s => { element.Pause(); },true);
        }
    }
    
    public class Command : ICommand
    {
        private Action<object> action;
        private bool canExecute;
        public event EventHandler CanExecuteChanged;
    
        public Command(Action<object> action,bool canExecute)
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

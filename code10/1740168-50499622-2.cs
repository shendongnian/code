    public class BlankCommand : ICommand 
    {
        public MyViewModel ViewModel { get; }
        public BlankCommand(MyViewModel vm)
        {
            this.ViewModel = vm;
        }
        public void Execute(object parameter) 
        {
            // parameter is the name of the property to modify
            
            var type = ViewModel.GetType();
            var prop = type.GetProperty(parameter as string);
            var value = prop.GetValue(ViewModel);
            if(string.IsNullOrEmpty(value))
                prop.SetValue(ViewModel, "[blank]");
        }
        public boolean CanExecute(object parameter) => true;
        public event EventHandler CanExecuteChanged;
    }

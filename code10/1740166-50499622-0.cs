    public class BlankCommand : ICommand 
    {
        public void Execute(object parameter) 
        {
            // assuming parameter is an instance of our ViewModel
            var vm = parameter as MyViewModel;
            if(string.IsNullOrEmpty(vm.District))
                vm.District = "[blank]";
        }
        public boolean CanExecute(object parameter) => true;
        public event EventHandler CanExecuteChanged;
    }

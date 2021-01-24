    public class SomeVm
    {
        public SomeVm()
        {
            // initialize SomeCommand here;
            // usually you need RelayCommand/DelegateCommand
            SomeCommand = new RelayCommand(SomeMethod);
        }
        public ICommand SomeCommand { get; }
        private void SomeMethod()
        {
        }
    }

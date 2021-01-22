    public class MyViewModel : ViewModelBase
    {
        public RelayCommand<CommandParam> MyCommand { get; private get; }
    
        public MyViewModel()
        {
            CreateCommands();
        }
    
        private void CreateCommands()
        {
            MyCommand = new RelayCommand<CommandParam>(MyCommandExecute);
        }
    
        private void MyCommandExecute(CommandParam parm)
        {
            // Action code...
        }
    }

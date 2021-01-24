    public class MyCommand : ICommand
    {
        private int _id;
        private string _name;
        public MyCommand(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public bool CanExecute(object parameter) => true;
        
        public void Execute(object parameter)
        {
            //TODO: Add your implementation
        }
    
        public event EventHandler CanExecuteChanged;
    }

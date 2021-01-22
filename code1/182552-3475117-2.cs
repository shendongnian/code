    public class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
            string dataFromView = (string)parameter;
    
            // ...
            MessageBox.Show(dataFromView);
        }
    }

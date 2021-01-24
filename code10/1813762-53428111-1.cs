    internal class DoSomethingCommand: ICommand
        {
            private VModel vm;
    
            public PlotPlane(VModel mainViewModel)
            {
                this.vm = mainViewModel;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public bool CanExecute(object parameter)
            {
                return true;
            }
    
            public void Execute(object parameter)
            {
    
                var id = (id)parameter;
                //do something, use vm to access your viewmodel
            
                
            }
        }

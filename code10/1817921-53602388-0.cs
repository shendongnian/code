    public CopyCommand : RelayCommandWithCannotExecuteReason
    {
        ViewModel _vm;
        public CopyCommand( ViewModel vm)
        { 
           _vm = vm;
        }
        public void Execute(object parameter) 
        {
           switch (_vm.SelectedTabIndex) 
           {
             case 1:
                _vm.Clipboard.SetData("First", object1);
                break;
             case 2:
               _vm.Clipboard.SetData("Second", object2;
                break;
            }
        }
         //implement other required methods...
    }

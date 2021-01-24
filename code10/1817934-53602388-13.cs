    public class CopyCommand : RelayCommandWithCannotExecuteReason
    {
        BaseTabViewModel _vm;
        public CopyCommand( BaseTabViewModel vm)
        { 
          _vm = vm;
        }

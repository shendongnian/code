    public class DelegateCommand : ICommand {
    
        //...code removed for brevity
     
        public void RaiseCanExecuteChanged() {
            if( CanExecuteChanged != null ) {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

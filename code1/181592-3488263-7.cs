    using System.Windows.Input;
    using WarpTab.Commands;
    
    namespace WarpTab.ViewModels
    {
      public class MainViewModel : ViewModelBase
      {
        public ICommand MyCommand { get; set; }
        public MainViewModel()
        {
          MyCommand = new DelegateCommand<object>(OnMyCommand, CanMyCommand);
        }
        
        private void OnMyCommand(object obj)
        {
          FocusControl = true;
          
          // process command here
          
          // reset to allow tab to continue to work
          FocusControl = false;
          return;
        }
        
        private bool CanMyCommand(object obj)
        {
          return true;
        }
        
        private bool _focusControl = false;
        public bool FocusControl
        {
          get
          {
            return _focusControl;
          }
          set
          {
            _focusControl = value;
            OnPropertyChanged("FocusControl");
          }
        }
      }
    }
    

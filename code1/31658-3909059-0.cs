     private void Cancel( Window window )
      {
         window.Close();
      }
      private ICommand _cancelCommand;
      public ICommand CancelCommand
      {
         get
         {
            return _cancelCommand ?? ( _cancelCommand = new Command.RelayCommand<Window>(
                                                          ( window ) => Cancel( window ),
                                                          ( window ) => ( true ) ) );
         }
      }

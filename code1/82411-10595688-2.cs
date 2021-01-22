    private void OnPropertyChanged<T>([CallerMemberName]string caller = null) {
         // make sure only to call this if the value actually changes
    
         var handler = PropertyChanged;
         if (handler != null) {
            handler(this, new PropertyChangedEventArgs(caller));
         }
    }

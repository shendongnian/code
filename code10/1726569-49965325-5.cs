    protected void NotifyOfPropertyChange(string name) {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) {
            handler(this, new PropertyChangedEventArgs(name));
            SaveCommand.RaiseCanExecuteChanged();
        }
    }

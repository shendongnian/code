    protected void OnPropertyChanged<T>(ref T field, T value, params object[] updateThese)
    {
        if (!EqualityComparer<T>.Default.Equals(field, value))
        {
            field = value;
            OnPropertyChanged(updateThese);
        }
    }
    protected void OnPropertyChanged(params object[] updateThese)
    {
        if (PropertyChanged != null)
        {
            foreach (string property in updateThese.Where(property => property is string))
                PropertyChanged(this, new PropertyChangedEventArgs(property));
    
            foreach (DelegateCommand<object> command in updateThese.Where(property => property is DelegateCommand<object>))
                command.RaiseCanExecuteChanged();
        }
    }

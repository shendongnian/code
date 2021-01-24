    private EventHandler _canExecuteChanged;
    public event EventHandler CanExecuteChanged
    {
       add
       {
          _canExecuteChanged += value;
          CommandManager.RequerySuggested += value;
       }
       remove
       {
          _canExecuteChanged -= value;
          CommandManager.RequerySuggested -= value;
       }
    }
    
    public void RaiseCanExecuteChanged()
    {
       if (!IsBusy)
          OnCanExecuteChanged();
    }
    
    protected virtual void OnCanExecuteChanged()
       => _canExecuteChanged?.Invoke(this, EventArgs.Empty);

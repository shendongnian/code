    public bool CanExecute(object parameter)
    {
        return myList.Count > 0;
    }
    private void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
    public void Execute(object parameter)
    {
        if(myList.Count > 0) {
            myList.Clear();
            OnCanExecuteChanged();
        }
    }

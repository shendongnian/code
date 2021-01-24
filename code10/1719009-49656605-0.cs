    public virtual void Execute(object parameter)
    {
        if (CanExecute(parameter)
            && _execute != null
            && (_execute.IsStatic || _execute.IsAlive))
        {
            _execute.Execute();
        }
    }

    public void Execute(object parameter)
    {
        if (!IsDebouncing) {
            IsDebouncing = true;
            AsyncUtils.DelayCall (DebouncePeriodMsec, () => {
                IsDebouncing = false;
            });
            _execute ();
        }
    }

    private RelayCommand _setNumberPagesCommand;
    public ICommand SetNumberPagesCommand
    {
        get
        {
            if (_setNumberPagesCommand == null)
            {
                int num;
                _setNumberPagesCommand = new RelayCommand(param => SetNumberOfPages(),
                    () => Int32.TryParse(NumberPagesToPrint, out num));
            }
            return _setNumberPagesCommand;
        }
    }

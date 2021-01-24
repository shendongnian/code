    private ICommand _ShowEntitiesCommand;
    public ICommand ShowEntitiesCommmand
    {
        get
        {
            if (_ShowEntitiesCommand == null)
            {
                _ShowEntitiesCommand = new RelayCommand(ShowEntities);
            }
            return _ShowEntitiesCommand;
        }
    }
    private void ShowEntities(object parameter)
    {
        SelectedViewModel = viewModelLocator.Get(parameter);
    }

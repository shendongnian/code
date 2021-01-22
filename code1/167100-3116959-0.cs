    RelayCommand _saveCommand;
    public ICommand SaveCommand
    {
      get
      {
        return _saveCommand ?? (_saveCommand = new RelayCommand(param => this.Save(),
                                                                param => this.CanSave ));
      }
    }

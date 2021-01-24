    private ICommand _selectBtnOnClickCommand;
    public ICommand SelectBtnOnClickCommand
    {
        get
        {
            if (_selectBtnOnClickCommand == null)
                _selectBtnOnClickCommand = new RelayCommand(o =>
                {
                    var selectedSites = (o as IList);
                    if (selectedSites != null)
                    {
                        foreach (var model in selectedSites.OfType<SiteUrlsModel>())
                        {
                            //
                        }
                    }
                });
            return _selectBtnOnClickCommand;
        }
    }

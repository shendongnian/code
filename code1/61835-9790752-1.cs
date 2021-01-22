    public MainScreenPresenter(IView _view)
    {
        _view.CloseView += Close;
    }
    private bool Close()
    {
        bool close = true;
        if (_view.IsDirty)
            close = _view.WillDiscardChanges();
        return close;
    }     

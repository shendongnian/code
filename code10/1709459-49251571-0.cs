    public Model SelectedModel
    {
        get { return mSelectedModel; }
        set
        {
            if (mSelectedModel != null)
                PropertyChangedEventManager.RemoveHandler(mSelectedModel, OnSelectedModelPropertyChanged, "");
            SetProperty(ref mSelectedModel, value);
            if (mSelectedModel != null)
                PropertyChangedEventManager.AddHandler(mSelectedModel, OnSelectedModelPropertyChanged, "");
            NotifyPropertyChanged(nameof(IsSelectedModelChecked));
        }
    }
    
    private void OnSelectedModelPropertyChanged( object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == nameof(Model.IsChecked))
            NotifyPropertyChanged(nameof(IsSelectedModelChecked));
    }

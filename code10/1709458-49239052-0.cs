    public Model SelectedModel
    {
        get { return mSelectedModel; }
        set
        {
            if (mSelectedModel != null)
                mSelectedModel.PropertyChanged -= OnSelectedModelPropertyChanged;
            SetProperty(ref mSelectedModel, value);
            if (mSelectedModel != null)
                mSelectedModel.PropertyChanged += OnSelectedModelPropertyChanged;
            NotifyPropertyChanged(nameof(IsSelectedModelChecked));
        }
    }
    private void OnSelectedModelPropertyChanged( object sender, PropertyChangedEventArgs args )
    {
        if (args.PropertyName == nameof(Model.IsChecked))
            NotifyPropertyChanged(nameof(IsSelectedModelChecked));
    }

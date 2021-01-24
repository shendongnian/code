    protected override void OnPropertyChanged(string propertyName)
    {
        if (propertyName == nameof(Reps))
        {
            RaisePropertyChanged(nameof(SetRepInfo));
        }
    }

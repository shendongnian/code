    public void RaisePropertyChanged([CallerMemberName]string caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        if (caller == nameof(HeightPX) || caller == nameof(HeightMM))
        {
            RaisePropertyChanged(nameof(MUpPX));
        }
    }

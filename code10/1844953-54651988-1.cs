    public void RaisePropertyChanged([CallerMemberName]string caller = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(caller));
            if (caller == nameof(HeightPX) || caller == nameof(HeightMM))
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MUpPX)));
            }
        }
    }

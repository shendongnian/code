    public int MathLevel
    {
        get => user.Skills [0].Level;
        set
        {
            user.Skills [0].Level = value;
            OnPropertyChanged("MathLevel");
        }
    }

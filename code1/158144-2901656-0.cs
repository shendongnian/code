    private int count;
    public int Count
    {
        get { return count; }
        set
        {
            if (count != value)
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
    }

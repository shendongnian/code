    public double ColumnWidth
    {
        get
        {
            if (this.ColumnIsVisible)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            OnPropertyChanged("ColumnWidth");
        }
    }

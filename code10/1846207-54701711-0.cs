    private string DateTimeStartVal = DateTime.Now.ToString().Substring(0, DateTime.Now.ToString().IndexOf(':')) + ":00:00";
    public string DateTimeStart
    {
        get { return DateTimeStartVal; }
        set
        {
            DateTimeStartVal = value;
            NotifyPropertyChanged("DateTimeStart");
        }
    }

    private string spl;
    public string Spl
           {
             get {return this.spl;}
             set
                {
                if (this.spl != value)
                {
                this.spl = value;
                OnPropertyChanged("SPL);
                }

    private IList currentCollection;
    public IList CurrentCollection
    {
       get { return this.currentCollection; }
       set
       {
           if (this.currentCollection != value)
           {
               this.currentCollection = value;
               var handler = this.PropertyChanged;
               if (handler != null)
                   handler(this, new PropertyChangedEventArgs("CurrentCollection");
           }
       }

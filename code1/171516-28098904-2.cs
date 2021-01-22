     private Int32 counterField;
    
     public Int32 Counter
     {
         get
         {
              return this.counterField;
         }
    
         set
         {
               if (this.counterField != value)
               {
                    this.counterField = value;
                    this.OnPropertyChanged("Counter");
                }
          }

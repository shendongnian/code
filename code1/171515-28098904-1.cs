     private Int32 counterField;
    
     public Int32 Field
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

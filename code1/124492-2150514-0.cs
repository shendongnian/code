       public int Age {
    
         get { return age; }
         set { 
              if ( age != value) {
                  age = value; 
                  OnAgeChanged();
              }
          }     
       }

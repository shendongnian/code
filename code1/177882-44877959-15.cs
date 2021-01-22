                Point initloc;
              Public ButObj(Point loc)  
        
     {   this.Location=initloc=loc ;   }
               Public bool isNearto(ButObj X)
                   { 
                     if (this.Location.X==X.Location.X || this.Location.Y==X.Location.Y)
                       return true;
            else  return false;
                   }
               Public bool isSettled()
                 {
                    if(this.Location==initloc)
                       return true ;
                    else return false;
                 }
             Public void Replace (ButObj X)
         {
               Point temp ;
                 temp=this.Location;
           this.Location=X.Location;
        X.Location=temp;
        }
             }

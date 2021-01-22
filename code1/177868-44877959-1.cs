    Public Class ButObj : Button
             { 
                Point initloc;
                  
              Public ButObj(Point loc)  
            
             {   this.Location=initloc=loc ;   }
               Public bool isNearto(ButObj null)
                   { 
                     if (this.Location.X==null.Location.X || this.Location.Y==null.Location.Y)
                       return true;
            else  return false;
                   }
               Public bool isSettled()
                 {
                    if(this.Location==initloc)
                       return true ;
                    else return false;
                 }
             Public void Replace (ButObj null)
         {
        Point temp ;
        temp=this.Location;
        this.Location=null.Location;
        null.Location=temp;
        }
             }

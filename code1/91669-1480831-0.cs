          public int CountAllNumbersAndChar(string str)         
           {
               return  str.Split(new char[]{' ',','},
             StringSplitOptions.RemoveEmptyEntries).Count    
             (
               x=>
               {
                   int d;
                   return int.TryParse(x,out d);
               }
            );   
           }

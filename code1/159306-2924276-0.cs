       public struct InPutDay
       {
           private int val;
           private bool isDef;
           private InPutDay( )  { } // private to prevent direct instantiation 
           private InPutDay(int value) { id=value; isDef = true; } 
     
           public bool HasValue { get { return isDef; } } 
           public bool isNull{ get { return !isDef; } } 
    
           public static InPutDay Null = new InPutDay(); 
           public static InPutDay Sun = new InPutDay(1); 
           public static InPutDay Mon = new InPutDay(2); 
           public static InPutDay Tue = new InPutDay(3); 
           public static InPutDay Wed = new InPutDay(4); 
           public static InPutDay Thu = new InPutDay(5); 
           public static InPutDay Fri = new InPutDay(6); 
           public static InPutDay Sat = new InPutDay(7); 
    
           public static InPutDay Parse(string s)
           {
               switch (s.ToUpper().Substring(0,3))
               {
                   case "SUN": return InPutDay.Sun;
                   case "MON": return InPutDay.Mon;
                   case "TUE": return InPutDay.Tue;
                   case "WED": return InPutDay.Wed;
                   case "THU": return InPutDay.Thu;
                   case "FRI": return InPutDay.Fri;
                   case "SAT": return InPutDay.Sat;
                   default return InPutDay.Null;
               }
           }
           public static implicit operator int(InPutDay inDay)
           { return val; }
           public static explicit operator InPutDay (int inDay)
           { 
               if (inDay > 0 && inDay < 8)
                  return new InPutDay(inDay);
               // either throw exception ....
               throw new ArgumentException(
                   "InPutDay integer values must be between 1 and 7.");
               // or return null instance
               return InPutDay.Null;
           }
           public static explicit operator InPutDay (string inDayName)
           {  return InPutDay.Parse(inDayName); }               
      }

    public static bool operator ==(ActiveApplication a, ActiveApplication b)
         {
         // same reference so equals is true - will be true for null == null
         if (object.ReferenceEquals(a, b))
            return true;
    
         // one is null and the other is not
         if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
            return false;
    
         // dealt with all combinations of null - compare fields
         return a.process_name == b.process_name && a.window_title == b.window_title;
         }
    
      public static bool operator !=(ActiveApplication a, ActiveApplication b)
         {
         return !(a == b);
         }

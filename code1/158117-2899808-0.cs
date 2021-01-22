    public static bool IsBefore6PM(System.DateTime _date)
    {
         if(_date.CompareTo(System.DateTime.Today.AddHours(18)) < 0 && _date.CompareTo(System.DateTime.Today) >= 0)
         {
              return true;
         }	
         else
         {
              return false;
         }
    }

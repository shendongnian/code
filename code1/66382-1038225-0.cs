     public DateTime BeginTimeStamp
     {
         get { return _dateTime; }
         set
         {
             // force the time to whatever you want
             _dateTime = value.Date;
         }
     }

    private DateTime? date 
    public DateTime? Date 
    { 
      get
         {
           if(date == DateTime.Min)
         {
             return null;
         }
             return date;
         }
       set
         {
             date = value;
         }
    }

    public void Page_Load( ... )
    {
         ...
         EventDate.Value = GetFirstOfMonth( DateTime.Today );
         EventDate2.Value = GetLastOfMonth( DateTime.Today );
         ...
    }

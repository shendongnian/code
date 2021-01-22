    public MyForm()
    {
      // Standard design time component initialization
      InitializeComponent();
      // enable the MonthCalendar's Layout event handler
      this.MyMonthCalendar.Layout += MyMonthCalendar_Layout;
    }
    /// MonthCalendar Layout Event Handler
    private void MyMonthCalendar_Layout;(object sender, LayoutEventArgs e)
    {
      // disable this event handler because we only need to do it one time
      this.MyMonthCalendar.Layout -= MyMonthCalendar_Layout;
      
      // initialize the MonthCalendar so its months are aligned like we want them to be
      // To show a calendar with only April, May, and June 2010 do this
      this.MyMonthCalendar.SetSelectionRange(new DateTime(2010, 4, 1), new DateTime(2010, 6, 30));
      // MyMonthCalendar.TodayDate can be any date you want
      // However, MyMonthCalendar.SetDate should be within the SelectionRange or you might scroll the calendar
      this.MyMonthCalendar.SetDate(new DateTime(2010, 6, 30));      
    }

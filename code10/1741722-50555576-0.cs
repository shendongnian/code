    public class MyApplication
    {
       // constructor injection
       private IGeneralCalendarService  _calendarService;
       public MyApplication(IGeneralCalendarService  calendarService)
       {
         _calendarService = calendarService;  
       }
    
       private void MyFunction()
       {
           _calendarService.CreateEvent(..., ...)
       }
    }

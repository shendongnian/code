    public class YourViewModel
    {
         private SomeService_service;
         public YourViewModel(SomeServiceyourService)
         {
              _service = yourService;
              _service.OnSomethingHappening += (s,a) =>
              {
                  //event handling
              };
         }
    }
    //etc.

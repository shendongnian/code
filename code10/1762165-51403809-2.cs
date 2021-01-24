    public class SomeController
    {
        private readonly Data _data;
        public SomeController(Data data) 
        {
           _data = data;
        }
        public IActionResult Get() 
        {
            // do something with _data here
            // don't new it up - it gets injected!
        }
        ...
    }
        

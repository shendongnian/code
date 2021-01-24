    public IActionResult Get(int settingToSet) 
    {
        return Ok(_anotherService.GetSomething(settingToSet)); 
    }
    public class AnotherService : IAnotherService 
    {
        public AnotherService(ISomeAnotherService service) 
        {
             _service = service;
        }
        public string GetSomething(int inputValue) 
        {
            int serviceResult = _service.GetSomething(inputValue);
        } 
     }

     public interface IAnotherService
     {
         string Run();
     }
    public class ProcessA
    {
        public string result;
        private readonly IAnotherService _anotherService;
        public ProcessA(IAnotherService anotherService)
        {
            this._anotherService = anotherService;
        }
        public string Run()
        {
            // Some other process here
            return _anotherService.Run();
        }   
    }

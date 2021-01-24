    public class MyClass
    {
        public MyClass(ToolService toolService)
        {
            _toolService = toolService;
        }
    
        public void MyMethod()
        {
            _toolService.ReadToolDetail(1);
        }
    }

    public class MyBusinessObject
    {
        private IDependency _dependency;
        public MyBusinessObject(IDependency dependency)   
        {   
            _dependency = dependency;   
        }   
   
        public virtual string DoSomething(string input)   
        {   
            // Process input   
            var info = _dependency.GetInfo();   
            var result = PerformInterestingStuff(input, info);   
            return result;   
        }   
    }
    public class LoggableBusinessObject : MyBusinessObject
    {
        private ILogger _logger;
        public LoggableBusinessObject(ILogger logger, IDependency dependency)
            : base(dependency)
        {
            _logger = logger;
        }
        public override string DoSomething(string input)
        {
            string result = base.DoSomething(input);
            if (result == "SomethingWeNeedToLog")
            {
                 _logger.Log(result);
            }
        }
    }

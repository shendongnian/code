    public class XAMLHelper
    {
        private readonly IVariableHandlerFactory _factory;
      
        public XAMLHelper(IVariableHandlerFactory factory)
        {
            _factory = factory;
        }
        public void HelpMe(string description)
        {
            var handler = _factory.Get(description);
 
            //do actual work using handler
        }
    }

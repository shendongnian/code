    public class ApiController
    {
        private readonly OtherClass _otherClass = new OtherClass(nameof(ApiController));
        public void GetMethod()
        {
            _otherClass.OtherMethod();
        }
    }
    public class OtherClass
    {
        private readonly string _controllerName;
        public OtherClass(string controllerName)
        {
            _controllerName = controllerName;
        }
        public void OtherMethod()
        {
            Console.WriteLine(_controllerName);
        }
    }

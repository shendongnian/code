    interface IMyService
    {
        string Get(Parameter param); // common stuff
        void GetInternal(Parameter param); // implementation specific stuff
    }
    abstract class MyServiceBase : IMyService
    {
        public string Get(Parameter param)
        {
            List<string> myList = new List<string>();
            GetInternal(param); // do service specific stuff
            return myList.ToString();
        }
    }
    class MyService1 : MyServiceBase
    {
        public GetInternal(Parameter param)
        {
            // service specific stuff
        }
    }

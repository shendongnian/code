    public class A
    {
        private readonly IThingThatDoesSomethingAndReturnsABoolean _thing;
        public A(IThingThatDoesSomethingAndReturnsABoolean thing)
        {
            _thing = thing;
        }
        protected bool AnotherMethodOfA()
        {
            bool anotherReturnValue = false;
            bool operationCheck = _thing.MethodThatReturnsBool();
            if (operationCheck)
            {
                //do something to set the value of anotherReturnValue
            }
            return anotherReturnValue;
        }
    }

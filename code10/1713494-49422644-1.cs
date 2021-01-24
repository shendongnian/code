    public class MyController
    {
        private readonly IMyType theType;
        public MyController(IMyType theType)
        {
            this.theType = theType; 
        }
        ....
    }

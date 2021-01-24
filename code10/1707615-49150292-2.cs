    public class Add : IOperations
    {
        Input obj;
        public Add(Input obj)
        {
            this.obj = obj;
        }
    
        public Result Process(Input obj)
        {
            //Perform Add here
            return new Result();
        }
    }
    
    public class Multiply : IOperations
    {
        Input obj;
        public Multiply(Input obj)
        {
            this.obj = obj;
        }
    
        public Result Process(Input obj)
        {
            //Perform multiply  here
            return new Result();
        }
    }

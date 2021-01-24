    public class Class1 
    { 
        public TIinterface tinterface{get;private set;}
        public Class1(TIinterface interface)
        {
            tinterface= interface;
        }
    }
    public class YourCustomImplementation:TIinterface 
    {
       public async Task<bool> RetrieveFromDataBase()
       {
            //do something
            return true;
       }
    }
     
    public class AnotherClass
    {
        Class1 c = new Class1();       
        public AnotherClass(Class1 obj)
        {
           c = obj;
        }
        public async Task<bool> ExecuteData()
        {
            var result = await c.tinterface.RetrieveFromDataBase();
            if (result)
            {
                //do some calculation
            }
            return true;
        }
    }

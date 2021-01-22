    class MyObject
    {
        public IDeclarer Declarer { get; set; }
    
        private MyObject(IWrapper wrapper,string name)
        {
            // set properties
        }
    
        public static MyObject Declare(IWrapper wrapper,string name)
        {
            //Some COM stuff with IWrapper
            MyObject newMyObject = new MyObject(wrapper,name);
            return Declarer.Declare(newMyObject);
        } 
    }
    
    public interface IDeclarer
    {
        MyObject Declare(MyObject obj);
    }
    
    public class ComDeclarer : IDeclarer
    {
        public MyObject Declare(MyObject obj)
        {
            // do COM work
            return comObj;
        }
    }
    
    public class TestDeclarer : IDeclarer
    {
        public MyObject Declare(MyObject obj)
        {
            // do nothing... or whatever
            return testObj;
        }
    }

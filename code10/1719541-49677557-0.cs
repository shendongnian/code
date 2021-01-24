    public class MyClass
    {
        public int Id { get; private set; }
    
        public int MyValue { get; set; }
    
        public MyClass(int id, int myValue)
        {
           this.Id = id;
           this.MyValue = myValue;
        }
    }

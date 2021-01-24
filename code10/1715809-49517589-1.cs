    public class MyValue
    {
        private static Random rnd = new Random();
    
        public int SomeInt { get; set; } = rnd.Next();
    }
    var myObjArray = new MyValue[] { new MyValue(), new MyValue(), new MyValue(), new MyValue() };
    
    var myAvg = myObjArray.Average(o => o.SomeInt);

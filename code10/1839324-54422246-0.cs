    public class A 
    {
        public MyProperties Property { get; set; }
        public A()
        {
            Property = new MyProperties();
        }
        //other stuff
    }
    public class MyProperties
    {
        public string Property1 { get; set; }
        public int Property2 { get; set; }
        public double Property3 { get; set; }
        public float Property4 { get; set; }
    }

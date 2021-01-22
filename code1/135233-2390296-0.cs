    public class MyClassB : MyClassA
    {
        public MyClassB(MyClassA a, string z)
        {
            this.PropertyA = a.PropertyA;
            this.PropertyB = a.PropertyB;
            // etc.
            this.PropertyZ = z;
        }
        public string PropertyZ { get; set; }
    }

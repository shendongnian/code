    public class MyClassA 
    { 
        public String Property_A { get; set; } 
        public String Property_B { get; set; } 
        public String Property_C { get; set; } 
        public String Property_D { get; set; } 
        ... 
        public String Property_Y { get; set; } 
    } 
     
    public class MyClassB: MyClassA 
    { 
        public MyClassB(MyClassA copy)
        {
            Property_A = copy.PropertyA;
            Property_B = copy.PropertyB;
            ...
        }
        public String Property_Z { get; set; } 
    } 

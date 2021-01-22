        public enum Test
        {
          
        }
    
        public enum ThisTest
        {
            MyVal1,
            MyVal2,
            MyVal3
        }
        public abstract class MyBase
        {
            public Test MyEnum { get; set; }
        }
        public class MyDerived : MyBase
        {
            public new ThisTest MyEnum { get; set; }
        }

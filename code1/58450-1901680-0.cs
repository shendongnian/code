    using System.Reflection;
    
    namespace TempTest
    {
        public class ClassA
        {
            public int IntProperty { get; set; }
        }
    
        public class ClassB
        {
            public ClassB()
            {
                MyProperty = new ClassA { IntProperty = 4 };
            }
            public ClassA MyProperty { get; set; }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                ClassB tester = new ClassB();
    
                PropertyInfo propInfo = typeof(ClassB).GetProperty("MyProperty");
                //get a type unsafe reference to ClassB`s property
                dynamic property = propInfo.GetValue(tester, null);
    
                //casted the property to its actual type dynamically
                int result = property.IntProperty; 
            }
        }
    }

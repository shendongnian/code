    using System.Math;
    using SuperMath = MyNamespace.Math;
    
    namespace MyNamespace
    {
        public class MyClass
        {
            public int SomeCalc(int a, int b)
            {
                 int result = Math.abs(a);
                 result = SuperMath::SomeFunc(a, b);
                 
                 return result;
            }
        }
    }

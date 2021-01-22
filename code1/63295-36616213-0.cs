    Used to obtain the System.Type object for a type. A typeof expression takes the following form:
    
    System.Type type = typeof(int);
    
    Example:
    
        public class ExampleClass
        {
           public int sampleMember;
           public void SampleMethod() {}
        
           static void Main()
           {
              Type t = typeof(ExampleClass);
              // Alternatively, you could use
              // ExampleClass obj = new ExampleClass();
              // Type t = obj.GetType();
        
              Console.WriteLine("Methods:");
              System.Reflection.MethodInfo[] methodInfo = t.GetMethods();
        
              foreach (System.Reflection.MethodInfo mInfo in methodInfo)
                 Console.WriteLine(mInfo.ToString());
        
              Console.WriteLine("Members:");
              System.Reflection.MemberInfo[] memberInfo = t.GetMembers();
        
              foreach (System.Reflection.MemberInfo mInfo in memberInfo)
                 Console.WriteLine(mInfo.ToString());
           }
        }
        /*
         Output:
            Methods:
            Void SampleMethod()
            System.String ToString()
            Boolean Equals(System.Object)
            Int32 GetHashCode()
            System.Type GetType()
            Members:
            Void SampleMethod()
            System.String ToString()
            Boolean Equals(System.Object)
            Int32 GetHashCode()
            System.Type GetType()
            Void .ctor()
            Int32 sampleMember
        */
    
    Example
    This sample uses the GetType method to determine the type that is used to contain the result of a numeric calculation. This depends on the storage requirements of the resulting number.
    
        class GetTypeTest
        {
            static void Main()
            {
                int radius = 3;
                Console.WriteLine("Area = {0}", radius * radius * Math.PI);
                Console.WriteLine("The type is {0}",
                                  (radius * radius * Math.PI).GetType()
                );
            }
        }
        /*
        Output:
        Area = 28.2743338823081
        The type is System.Double
        */

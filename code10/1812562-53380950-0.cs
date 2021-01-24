    using System;
    using System.Reflection;
    namespace YourMethodNamespace
    {    
        public class YourMethodClass
        {
            public void function1()
            {
                Console.WriteLine("Function-1");
            }
        
            public void function2()
            {
                Console.WriteLine("Function-2");
            }
        
            ...
    
            public void function200()
            {
                Console.WriteLine("Function-200");
            }
        
            public static void invokeMethodsDynamically(int randomNumber){
                Type yourClassType = typeof(YourMethodClass);
                ConstructorInfo yourClassConstructorInfo = yourClassType.GetConstructor(Type.EmptyTypes);
                object yourClassObject = yourClassConstructorInfo.Invoke(new object[]{}); 
                //If the constructor has parameters, then we can pass them by this way. Like below;
                /*ConstructorInfo yourClassConstructorInfo = yourClassType.GetConstructor(new[]{typeof(int)});
                object yourClassObject = yourClassConstructorInfo.Invoke(new object[]{3});
                */
    
                MethodInfo[] methodInfoArr = yourClassType.GetMethods();
                foreach(MethodInfo methodInfo in methodInfoArr){
                    if(methodInfo.Name == "function" + randomNumber){
                        methodInfo.Invoke(yourClassObject, null);
                    }
                }
            }
        }
    }

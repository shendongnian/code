    using System;
    using YourMethodNamespace;
    namespace YourProgramNamespace
    {       
        public class YourProgramClass
        {
            public static void Main()
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 201);             
                    
                //If Methods.cs is in another Assembly
                /*string pathToDllAssembly = @"Domain.dll";
                Assembly dllAssembly = Assembly.LoadFrom(pathToDllAssembly);
                Type methodsClassType = dllAssembly.GetType("YourMethodNamespace.YourMethodClass");
                ConstructorInfo methodClassConstructorInfo = methodsClassType.GetConstructor(Type.EmptyTypes);
                object methodsClassObject = methodClassConstructorInfo.Invoke(new object[]{});
                MethodInfo methodInfo = methodsClassType.GetMethod("invokeMethodsDynamically");
                methodInfo.Invoke(methodsClassObject, new object[]{randomNumber});
                */
                YourMethodClass.invokeMethodsDynamically(randomNumber, null);
            }
        }
    }

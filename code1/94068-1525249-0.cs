    using System;
    using System.Linq;
    using System.Reflection;
    using System.Diagnostics;
    
    namespace ConsoleApplication8
    {
        public interface ITest
        {
            void Test();
        }
    
        public class Test : ITest
        {
            void ITest.Test()
            {
                throw new NotImplementedException();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Type interfaceType = typeof(ITest);
                Type classType = typeof(Test);
    
                InterfaceMapping map = classType.GetInterfaceMap(interfaceType);
    
                MethodInfo testMethodViaInterface = interfaceType.GetMethods()[0];
                MethodInfo implementingMethod = testMethodViaInterface.GetImplementingMethod(classType);
    
                Console.Out.WriteLine("interface: " + testMethodViaInterface.Name);
                if (implementingMethod != null)
                    Console.Out.WriteLine("class: " + implementingMethod.Name);
                else
                    Console.Out.WriteLine("class: unable to locate"); 
                
                Console.Out.Write("Press enter to exit...");
                Console.In.ReadLine();
            }
        }
    
        public static class TypeExtensions
        {
            /// <summary>
            /// Gets the corresponding <see cref="MethodInfo"/> object for
            /// the method in a class that implements a specific method
            /// from an interface.
            /// </summary>
            /// <param name="interfaceMethod">
            /// The <see cref="MethodInfo"/> for the method to locate the
            /// implementation of.</param>
            /// <param name="classType">
            /// The <see cref="Type"/> of the class to find the implementing
            /// method for.
            /// </param>
            /// <returns>
            /// The <see cref="MethodInfo"/> of the method that implements
            /// <paramref name="interfaceMethod"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// <para><paramref name="interfaceMethod"/> is <c>null</c>.</para>
            /// <para>- or -</para>
            /// <para><paramref name="classType"/> is <c>null</c>.</para>
            /// </exception>
            /// <exception cref="ArgumentException">
            /// <para><paramref name="interfaceMethod"/> is not defined in an interface.</para>
            /// </exception>
            public static MethodInfo GetImplementingMethod(this MethodInfo interfaceMethod, Type classType)
            {
                #region Parameter Validation
    
                if (Object.ReferenceEquals(null, interfaceMethod))
                    throw new ArgumentNullException("interfaceMethod");
                if (Object.ReferenceEquals(null, classType))
                    throw new ArgumentNullException("classType");
                if (!interfaceMethod.DeclaringType.IsInterface)
                    throw new ArgumentException("interfaceMethod", "interfaceMethod is not defined by an interface");
    
                #endregion
    
                InterfaceMapping map = classType.GetInterfaceMap(interfaceMethod.DeclaringType);
                MethodInfo result = null;
    
                for (Int32 index = 0; index < map.InterfaceMethods.Length; index++)
                {
                    if (map.InterfaceMethods[index] == interfaceMethod)
                        result = map.TargetMethods[index];
                }
    
                Debug.Assert(result != null, "Unable to locate MethodInfo for implementing method");
    
                return result;
            }
        }
    }

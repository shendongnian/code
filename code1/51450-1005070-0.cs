    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Reflection;
    namespace Test
    {
        public static class Invoker
        {
            public static object CreateAndInvoke(string typeName, object[] constructorArgs, string methodName, object[] methodArgs)
            {
                Type type = Type.GetType(typeName);
                object instance = Activator.CreateInstance(type, constructorArgs);
                MethodInfo method = type.GetMethod(methodName);
                return method.Invoke(instance, methodArgs);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Default constructor, void method
                Invoker.CreateAndInvoke("Test.Tester", null, "TestMethod", null);
                
                // Constructor that takes a parameter
                Invoker.CreateAndInvoke("Test.Tester", new[] { "constructorParam" }, "TestMethodUsingValueFromConstructorAndArgs", new object[] { "moo", false });
                // Constructor that takes a parameter, invokes a method with a return value
                string result = (string)Invoker.CreateAndInvoke("Test.Tester", new object[] { "constructorValue" }, "GetContstructorValue", null);
                Console.WriteLine("Expect [constructorValue], got:" + result);
                Console.ReadKey(true);
            }
        }
        public class Tester
        {
            public string _testField;
            public Tester()
            {
            }
            public Tester(string arg)
            {
                _testField = arg;
            }
            public void TestMethod()
            {
                Console.WriteLine("Called TestMethod");
            }
            public void TestMethodWithArg(string arg)
            {
                Console.WriteLine("Called TestMethodWithArg: " + arg);
            }
            public void TestMethodUsingValueFromConstructorAndArgs(string arg, bool arg2)
            {
                Console.WriteLine("Called TestMethodUsingValueFromConstructorAndArg " + arg + " " + arg2 + " " + _testField);
            }
            public string GetContstructorValue()
            {
                return _testField;
            }
        }
    }

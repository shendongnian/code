    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;
    using NUnit.Framework;
    
    namespace DynamicMethodInvocation
    {
    
        [TestFixture]
        public class Tests
        {
            [Test]
            public void Test()
            {
                // from your database 
                string assemblyQualifiedTypeName = "DynamicMethodInvocation.TestType, DynamicMethodInvocation";
                string methodName = "DoSomething";
    
                // this is how you would get the strings to put in your database
                string enumString = Executor.ConvertToString(typeof(AttributeTargets), AttributeTargets.Assembly);
                string colorString = Executor.ConvertToString(typeof(Color), Color.Red);
                string stringString = "Hmm... String?";
    
                object result = Executor.ExecuteMethod(assemblyQualifiedTypeName, methodName,
                                                       new[] { enumString, colorString, stringString });
    
                Assert.IsInstanceOf<bool>(result);
                Assert.IsTrue((bool)result);
            }
        }
    
    
        public class TestType
        {
            public bool DoSomething(AttributeTargets @enum, Color color, string @string)
            {
                return true;
            }
        }
    
        public class Executor
        {
            public static object ExecuteMethod(string assemblyQualifiedTypeName, string methodName,
                                               string[] parameterValueStrings)
            {
                Type targetType = Type.GetType(assemblyQualifiedTypeName);
                MethodBase method = targetType.GetMethod(methodName);
    
                ParameterInfo[] pInfo = method.GetParameters();
                var parameterValues = new object[parameterValueStrings.Length];
    
                for (int i = 0; i < pInfo.Length; i++)
                {
                    parameterValues[i] = ConvertFromString(pInfo[i].ParameterType, parameterValueStrings[i]);
                }
    
                // assumes you are instantiating the target from db and that it has a parameterless constructor
                // otherwise, if the target is already known to you and instantiated, just use it...
    
                return method.Invoke(Activator.CreateInstance(targetType), parameterValues);
            }
    
    
            public static string ConvertToString(Type type, object val)
            {
                if (val is string)
                {
                    return (string) val;
                }
                TypeConverter tc = TypeDescriptor.GetConverter(type);
                if (tc == null)
                {
                    throw new Exception(type.Name + " is not convertable to string");
                }
                return tc.ConvertToString(null, CultureInfo.InvariantCulture, val);
            }
    
            public static object ConvertFromString(Type type, string val)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(type);
                if (tc == null)
                {
                    throw new Exception(type.Name + " is not convertable.");
                }
                if (!tc.IsValid(val))
                {
                    throw new Exception(type.Name + " is not convertable from " + val);
                }
    
                return tc.ConvertFrom(null, CultureInfo.InvariantCulture, val);
            }
        }
    
    }

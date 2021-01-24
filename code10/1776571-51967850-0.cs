    using PostSharp.Aspects;
    using PostSharp.Reflection;
    using PostSharp.Serialization;
    using System;
    using System.Reflection;
    
    namespace LazySingletonSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestClass.Instance.SayHello();
                TestClass.Instance.SayHello();
                TestClass.Instance.SayHello();
            }
        }
    
        public class TestClass
        {
            [LazySingleton]
            public static TestClass Instance;
    
            public void SayHello()
            {
                Console.WriteLine("Hello from singleton!");
            }
        }
        // TODO: Restrict usage
        [PSerializable]
        public sealed class LazySingletonAttribute : LocationInterceptionAspect
        {
            object singletonInstance;
            ConstructorInfo constructor;
    
            public override bool CompileTimeValidate(LocationInfo locationInfo)
            {
                // TODO: check that:
                // - field name is "Instance"
                // - field type is the same as the declaring type
                // - there is only a default constructor
                // - the constructor is private
                // - the constructor is not called anywhere
                // - the field is not set anywhere
    
                return true;
            }
            public override void CompileTimeInitialize(LocationInfo targetLocation, AspectInfo aspectInfo)
            {
                this.constructor = targetLocation.DeclaringType.GetConstructor(new Type[] { });
            }
    
            public override void OnGetValue(LocationInterceptionArgs args)
            {
                if (this.singletonInstance == null)
                {
                    Console.WriteLine("Creating singleton instance.");
                    this.singletonInstance = constructor.Invoke(new object[] { });
                }
                Console.WriteLine("Returning singleton instance.");
                args.Value = this.singletonInstance;
            }
            public override void OnSetValue(LocationInterceptionArgs args)
            {
                throw new InvalidOperationException();
            }
        }
    }

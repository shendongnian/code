    using System;
    using System.Reflection;
    
    namespace MyApplication
    {
        class Application
        {
            static void Main()
            {
                Type type = Type.GetType("MyApplication.Action");
                if (type == null)
                {
                    throw new Exception("Type not found.");
                }
                var instance = Activator.CreateInstance(type);
                //or
                var newClass = System.Reflection.Assembly.GetAssembly(type).CreateInstance("MyApplication.Action");
            }
        }
    
        public class Action
        {
            public string key { get; set; }
            public string Value { get; set; }
        }
    }

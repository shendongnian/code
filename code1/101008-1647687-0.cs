        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.Linq;
        using System.Reflection;
    
        namespace StringSwitcher
        { 
        class Program
        {
            static void Main(string[] args)
            {
                "noAction".Execute(); //No action, since no corresponding method defined
                "Hello".Execute();    //Calls Greet method
                "world".Execute();    //Calls Shout method
                "example".Execute();  //Calls Shout method
                Console.ReadKey();
            }
    
            //Handles only one keyword
            [Keywords("Hello")]
            static public void Greet(string s)
            {
                Console.WriteLine(s + " world!");
            }
    
            //Handles multiple keywords
            [Keywords("world", "example")]
            static public void Shout(string s)
            {
                Console.WriteLine(s + "!!");
            }
        }
    
        internal static class ActionBrokerExtensions
        {
            static Dictionary<string, MethodInfo> actions;
    
            static ActionBrokerExtensions()
            {
                //Initialize lookup mechanism once upon first Execute() call
                actions = new Dictionary<string, MethodInfo>();
                //Find out which class is using this extension
                Type type = new StackTrace(2).GetFrame(0).GetMethod().DeclaringType;
                //Get all methods with proper attribute and signature
                var methods = type.GetMethods().Where(
                method => Attribute.GetCustomAttribute(method, typeof(KeywordsAttribute)) is KeywordsAttribute &&
                          method.GetParameters().Length == 1 &&
                          method.GetParameters()[0].ParameterType.Equals(typeof(string)));
                //Fill the dictionary
                foreach (var m in methods)
                {
                    var att = (Attribute.GetCustomAttribute(m, typeof(KeywordsAttribute)) as KeywordsAttribute);
                    foreach (string str in att.Keywords)
                    {
                        actions.Add(str, m);
                    }
                }
            }
    
            public static void Execute(this string input)
            {
                //Invoke method registered with keyword 
                MethodInfo mi;
                if (actions.TryGetValue(input, out mi))
                {
                    mi.Invoke(null, new[] { input });
                }
            }
        }
    
        [AttributeUsage(AttributeTargets.Method)]
        internal class KeywordsAttribute : Attribute
        {
            private ICollection<string> keywords;
            public KeywordsAttribute(params String[] strings)
            {
                keywords = new List<string>(strings);
            }
    
            public ICollection<string> Keywords
            {
                get { return keywords; }
            }
        }
    }

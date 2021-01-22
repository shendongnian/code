    using System;
    using System.Threading;
    using System.Reflection;
    using System.Collections.Generic;
    
    namespace Obfuscation
    {
        public class Program
        {
            static Type[] robotArray = new Type[] { typeof(Program) };
            static List<Type> robotList = new List<Type>(robotArray);
    
            internal void Run()
            {
                Console.WriteLine("Do stuff here");
            }
    
            internal static void RunInstance(object threadParam)
            {
                Type t = (Type)threadParam;
                object o = Activator.CreateInstance((Type)t);
                t.InvokeMember("Run", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, o, null);
            }
    
            public static void Main(string[] args)
            {
                for (int i = 0; i < robotList.Count; i++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(RunInstance), robotList[i]);
                }
            }
        }
    }

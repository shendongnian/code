    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
     
    namespace ReflectPrivateMembers
    {
        class Program
        {
            static void Main(string[] args)
            {
                ConstructorInfo ci = typeof(Hello).GetConstructor(BindingFlags.NonPublic| BindingFlags.Instance ,null,System.Type.EmptyTypes,null);
                object helloObject = ci.Invoke(System.Type.EmptyTypes);
                MethodInfo[] helloObjectMethods = helloObject.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly| BindingFlags.Instance );
     
                foreach (MethodInfo mi in helloObjectMethods)
                {
                    mi.Invoke(helloObject, System.Type.EmptyTypes);
                }
                Console.ReadLine();
            }
        }
        public class Hello
        {
            private Hello()
            {
                Console.WriteLine("Private Constructor");
            }
            public void HelloPub()
            {
                Console.WriteLine("Public Hello");
            }
            private void HelloPriv()
            {
                Console.WriteLine("Private Hello");
            }
        }
    }

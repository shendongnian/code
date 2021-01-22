    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Reflection;
    interface IFoo
    {
        void AAA(); // just to push Bar to index 1
        [Description("abc")]
        void Bar();
    }
    class Foo : IFoo
    {
        public void AAA() { } // just to satisfy interface
        static void Main()
        {
            IFoo foo = new Foo();
            foo.Bar();
        }
        void IFoo.Bar()
        {
            GetAttribute();
        }
    
        void GetAttribute()
        { // simplified just to obtain the [Description]
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase classMethod = stackFrame.GetMethod();
            InterfaceMapping map = GetType().GetInterfaceMap(typeof(IFoo));
            int index = Array.IndexOf(map.TargetMethods, classMethod);
            MethodBase iMethod = map.InterfaceMethods[index];
            string desc = ((DescriptionAttribute)Attribute.GetCustomAttribute(iMethod, typeof(DescriptionAttribute))).Description;
        }
    }

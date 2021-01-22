    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.Dynamic;
    using System.Runtime.CompilerServices;
    
    class Test
    {
        public static object GetDynamicValue(dynamic o, string name)
        {
            CallSite<Func<CallSite, object, object>> site 
                = CallSite<Func<CallSite, object, object>>.Create
                (Binder.GetMember(CSharpBinderFlags.None, name, 
                 typeof(Test), new CSharpArgumentInfo[] 
                 { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            return site.Target(site, o);
        }
        
        static void Main()
        {
            Console.WriteLine(GetDynamicValue("hello", "Length"));
        }
    }

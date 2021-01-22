    using System;
    using System.Reflection;
    
    public struct Foo
    {
        readonly string value;
        
        public Foo(string value)
        {
            this.value = value;
        }
        
        public string DemoMethod()
        {
            return value;
        }
    }
    
    class Test
    {
        delegate TResult RefFunc<TArg, TResult>(ref TArg arg);
        
        static void Main()
        {
            MethodInfo method = typeof(Foo).GetMethod
                ("DemoMethod", BindingFlags.Instance | BindingFlags.Public,
                 null, new Type[]{}, null);
            RefFunc<Foo, string> func = (RefFunc<Foo, string>)
                Delegate.CreateDelegate(typeof(RefFunc<Foo, string>),
                                        null,
                                        method);
            
            Foo y = new Foo("hello");
            string x = func(ref y);
            
            Console.WriteLine(x);
        }
    }

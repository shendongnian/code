    using System;
    using System.Reflection;
    class Foo
    {
        public string Bar { get; set; }
    }
    class Program
    {
        static void Main()
        {
            PropertyInfo prop = typeof(Foo).GetProperty("Bar");
            Foo foo = new Foo();
    
            // create an open "getter" delegate
            Func<Foo, string> getForAnyFoo = (Func<Foo, string>)
                Delegate.CreateDelegate(typeof(Func<Foo, string>), null,
                    prop.GetGetMethod());
    
            Func<string> getForFixedFoo = (Func<string>)
                Delegate.CreateDelegate(typeof(Func<string>), foo,
                    prop.GetGetMethod());
    
            Action<Foo,string> setForAnyFoo = (Action<Foo,string>)
                Delegate.CreateDelegate(typeof(Action<Foo, string>), null,
                    prop.GetSetMethod());
    
            Action<string> setForFixedFoo = (Action<string>)
                Delegate.CreateDelegate(typeof(Action<string>), foo,
                    prop.GetSetMethod());
    
            setForAnyFoo(foo, "abc");
            Console.WriteLine(getForAnyFoo(foo));
            setForFixedFoo("def");
            Console.WriteLine(getForFixedFoo());
        }
    }

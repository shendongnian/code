    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            Bar b1 = Foo.create<Bar>(42);
            b1.ShowDataMember("b1");
    
            Bar b2 = Bar.create<Bar>(43); // Just to show `Foo.create` vs. `Bar.create` doesn't matter
            b2.ShowDataMember("b2");
        }
    
        class Foo
        {
            public int DataMember { get; private set; }
            
            public static T create<T>(int i) where T: Foo, new()
            {
                T obj = new T();
                obj.DataMember = i;
                return obj;
            }
        }
        
        class Bar : Foo
        {
            public void ShowDataMember(string prefix)
            {
                Console.WriteLine(prefix + ".DataMember = " + this.DataMember);
            }
        }
    }

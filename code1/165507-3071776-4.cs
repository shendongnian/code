    using System;
    
    namespace ConsoleApplication3
    {
        abstract class Param
        {
            public abstract bool Foo();
            public abstract bool Bar();
            public abstract void Baz();
    
            public static IntParam Create(int value)
            {
                return new IntParam(value);
            }
    
            public static StringParam Create(string value)
            {
                return new StringParam(value);
            }
        }
    
        abstract class Param<T> : Param {
            private T value;
    
            protected Param() { }
    
            protected Param(T value) { this.value = value; }
    
            public T Value {
                get { return this.value; }
                set { this.value = value; }
            }
        }
    
        class IntParam : Param<int>
        {
            public IntParam() { }
            public IntParam(int value) : base(value) { }
    
            public override bool Foo() { return true; }
            public override bool Bar() { return true; }
    
            public override void Baz()
            {
                Console.WriteLine("int param value is " + this.Value);
            }
        }
    
        class StringParam : Param<string>
        {
            public StringParam() { }
            public StringParam(string value) : base(value) { }
    
            public override bool Foo() { return true; }
            public override bool Bar() { return true; }
    
            public override void Baz()
            {
                Console.WriteLine("String param value is " + this.Value);
            }
        }
    
        class Program
        {
            static void g(Param p1)
            {
                if (p1.Foo()) { p1.Baz(); }
            }
    
            static void g(Param p1, Param p2)
            {
                if (p1.Foo()) { p1.Baz(); }
                if (p2.Bar()) { p2.Baz(); }
            }
    
            static void Main(string[] args)
            {
                Param p1 = Param.Create(12);
                Param p2 = Param.Create("viva");
    
                g(p1);
                g(p2);
                g(p1, p1);
                g(p1, p2);
                g(p2, p1);
                g(p2, p2);
    
                Console.ReadKey();
            }
        }
    }

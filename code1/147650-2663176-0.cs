    class Cody
    {
        public virtual void Foo()
        {
            Console.WriteLine("Cody says: Hello World!");
        }
    }
    class Bob : Cody
    {
        public override void Foo()
        {
            base.Foo();
            Console.WriteLine("Bob says: Hello World!");
            base.Foo();
        }
    }

    abstract class MyBaseClass
    {
         public abstract void writeSomething();
    }
    
    class DerivedClass1 : MyBaseClass
    {
        public override void writeSomething()
        {
            Writeln("something else here  1");
        }
    }
    class DerivedClass2 : MyBaseClass
    {
        public override void writeSomething()
        {
            Writeln("something else here  2");
        }
    }

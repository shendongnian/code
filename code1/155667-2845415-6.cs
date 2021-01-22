    using System;
    using NUnit.Framework;
    
    namespace ScratchPad
    {
        [TestFixture]
        public class Class1
        {
            [Test]
            public void InheritanceHiding()
            {
                var b = new Base();
                var d = new Derived();
    
                var baseSomeProperty = b.SomeProperty;
                var derivedSomeProperty = d.SomeProperty;
    
                b.GetSomeProperty();
                d.GetSomeProperty();
            }
        }
    
        public class Base
        {
            public string SomeProperty
            {
                get
                {
                    Console.WriteLine("Getting Base.SomeProperty");
                    return "Base.SomeProperty";
                }
            }
    
            public string GetSomeProperty()
            {
                return SomeProperty;
            }
        }
    
        public class Derived : Base
        {
            protected new int SomeProperty
            {
                get
                {
                    Console.WriteLine("Getting Derived.SomeProperty");
                    return 3; //Determined by random roll of the dice.
                }
            }
    
            public new int GetSomeProperty()
            {
                return SomeProperty;
            }
        }
    }

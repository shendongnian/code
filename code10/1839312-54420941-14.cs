    using System;
    using System.Globalization;
    
    namespace Visitor
    {
        class BaseClass
        {
        }
    
        abstract class BaseClassWithVisitor : BaseClass
        {
            public abstract void AcceptVisitor(Visitor visitor);
        }
    
        abstract class Child<T> : BaseClassWithVisitor
        {
            public T Value;
        }
    
        class IntChild : Child<int>
        {
            public override void AcceptVisitor(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
        class FloatChild : Child<float>
        {
            public override void AcceptVisitor(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
        class StringChild : Child<string>
        {
            public override void AcceptVisitor(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
    
        class Visitor
        {
            public object Value;
    
            public void Visit(IntChild intChild)
            {
                intChild.Value = int.Parse(Value.ToString());
            }
            public void Visit(FloatChild floatChild)
            {
                floatChild.Value = float.Parse(Value.ToString(), CultureInfo.InvariantCulture);
            }
            public void Visit(StringChild stringChild)
            {
                stringChild.Value = Value.ToString();
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                var visitor = new Visitor { Value = "12345" };
                var intChild = new IntChild();
                intChild.AcceptVisitor(visitor);
    
                visitor = new Visitor { Value = "1.2345" };
                var floatChild = new FloatChild();
                floatChild.AcceptVisitor(visitor);
    
                visitor = new Visitor { Value = "Hello World" };
                var stringChild = new StringChild();
                stringChild.AcceptVisitor(visitor);
    
                Console.WriteLine("intChild.Value    = {0}", intChild.Value);
                Console.WriteLine("floatChild.Value  = {0}", floatChild.Value);
                Console.WriteLine("stringChild.Value = {0}", stringChild.Value);
            }
        }
    }

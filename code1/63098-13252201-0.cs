    using System;
    
    namespace TypeCaster
    {
        class Program
        {
            internal static void Main(string[] args)
            {
                Parent p = new Parent() { name = "I am the parent", type = "TypeCaster.ChildA" };
                dynamic a = Convert.ChangeType(new ChildA(p.name), Type.GetType(p.type));
                Console.WriteLine(a.Name);
    
                p.type = "TypeCaster.ChildB";
                dynamic b = Convert.ChangeType(new ChildB(p.name), Type.GetType(p.type));
                Console.WriteLine(b.Name);
            }
        }
    
        internal class Parent
        {
            internal string type { get; set; }
            internal string name { get; set; }
    
            internal Parent() { }
        }
    
        internal class ChildA : Parent
        {
            internal ChildA(string name)
            {
                base.name = name + " in A";
            }
    
            public string Name
            {
                get { return base.name; }
            }
        }
    
        internal class ChildB : Parent
        {
            internal ChildB(string name)
            {
                base.name = name + " in B";
            }
    
            public string Name
            {
                get { return base.name; }
            }
        }
    }

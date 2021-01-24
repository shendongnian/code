    using System;
    
    public class Base
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public Base(string p1, string p2)
        {
            prop1 = p1;
            prop2 = p2;
        }
        public virtual void print()
        {
            Console.WriteLine(prop1 + " " + prop2);
        }
    }
    
    public class cChild : Base
    {
        public cChild() : base("", "")
        {
        }
        public override void print()
        {
            Console.WriteLine(Base.prop1 + "......" + Base.prop2);
        }
        public static cChild ofBase(Base papa)
        {
            cChild r = new cChild();
            r.prop1 = papa.prop1;
            r.prop2 = papa.prop2;
            return r;
        }
    }

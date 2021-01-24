    using System;
    
    public interface printable
    {
        string prop1 { get; set; }
        string prop2 { get; set; }
        void print();
    }
    
    public class Base : printable
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
    
    public class cChild : printable
    {
        public new static explicit operator cChild(Base A)
        {
            cChild r = new cChild();
            r.prop1 = A.prop1;
            r.prop2 = A.prop2;
            return r;
        }
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public void print()
        {
            Console.WriteLine(prop1 + "......" + prop2);
        }
    }

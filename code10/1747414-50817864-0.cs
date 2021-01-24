    using System;
    
    class MyClass
    {
        public readonly struct Immutable { public readonly int I; public void SomeMethod() { } }
        public struct Mutable { public int I; public void SomeMethod() { } }
    
        public void Test(Immutable immutable, Mutable mutable, int i, DateTime dateTime)
        {
            InImmutable(immutable);
            InMutable(mutable);
            InInt32(i);
            InDateTime(dateTime);
        }
    
        void InImmutable(in Immutable x) { x.SomeMethod(); }
        void InMutable(in Mutable x) { x.SomeMethod(); }
        void InInt32(in int x) { x.ToString(); }
        void InDateTime(in DateTime x) { x.ToString(); }
    
        public static void Main(string[] args) { }
    }

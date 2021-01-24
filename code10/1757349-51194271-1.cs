    class A
    {
         virtual void CheckDerived() { throw new NotImplementedException(); }
    }
    class A0 : A
    {
         void override CheckDerived() { Console.WriteLine("A0"); }
    }
    class A1 : A
    {
         void override CheckDerived() { Console.WriteLine("A1"); }
    }

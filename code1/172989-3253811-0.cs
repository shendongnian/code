    public static Type GetCurrentType<T>(this T obj)
    {
        return typeof(T);
    }
    public static void Main()
    {
      MyBaseClass myBase = new MyBaseClass();
      MyDerivedClass myDerived = new MyDerivedClass();
      object o = myDerived;
      MyBaseClass b = myDerived;
    
      Console.WriteLine("mybase: Type is {0}", myBase.GetCurrentType());
      Console.WriteLine("myDerived: Type is {0}", myDerived.GetCurrentType());
      Console.WriteLine("object o = myDerived: Type is {0}", o.GetCurrentType());
      Console.WriteLine("MyBaseClass b = myDerived: Type is {0}", b.GetCurrentType());
    }
    /*
    This code produces the following output.
    mybase: Type is ValidatorTest.MyBaseClass
    myDerived: Type is ValidatorTest.MyDerivedClass
    object o = myDerived: Type is System.Object
    MyBaseClass b = myDerived: Type is ValidatorTest.MyBaseClass
    */

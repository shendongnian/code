    private static void Main (string[] args)
    {
    // Test with Foo and Fooby for verification of the problem.
      // definition of Foo and Fooby copied from
      // https://blog.mischel.com/2013/01/05/inheritance-and-iequatable-do-not-mix/
      // and not added in this post
      var fooby1 = new Fooby (0, "hello");
      var fooby2 = new Fooby (0, "goodbye");
      Foo foo1 = fooby1;
      Foo foo2 = fooby2;
    // all false, as expected
      bool bEqualFooby12a = fooby1.Equals (fooby2);
      bool bEqualFooby12b = fooby2.Equals (fooby1);
      bool bEqualFooby12c = object.Equals (fooby1, fooby2);
      bool bEqualFooby12d = object.Equals (fooby2, fooby1);
    // 2 true (wrong), 2 false
      bool bEqualFoo12a = foo1.Equals (foo2);  // unexpectedly "true": wrong result, because "wrong" overload is called!
      bool bEqualFoo12b = foo2.Equals (foo1);  // unexpectedly "true": wrong result, because "wrong" overload is called!
      bool bEqualFoo12c = object.Equals (foo1, foo2);
      bool bEqualFoo12d = object.Equals (foo2, foo1);
    // own test
      CBase oB = new CBase (1);
      CDerived oD1 = new CDerived (1, 2);
      CDerived oD2 = new CDerived (1, 2);
      CDerived oD3 = new CDerived (1, 3);
      CDerived oD4 = new CDerived (2, 2);
      CBase oB1 = oD1;
      CBase oB2 = oD2;
      CBase oB3 = oD3;
      CBase oB4 = oD4;
    // all false, as expected
      bool bEqualBD1a = object.Equals (oB, oD1);
      bool bEqualBD1b = object.Equals (oD1, oB);
      bool bEqualBD1c = oB.Equals (oD1);
      bool bEqualBD1d = oD1.Equals (oB);
    // all true, as expected
      bool bEqualD12a = object.Equals (oD1, oD2);
      bool bEqualD12b = object.Equals (oD2, oD1);
      bool bEqualD12c = oD1.Equals (oD2);
      bool bEqualD12d = oD2.Equals (oD1);
      bool bEqualB12a = object.Equals (oB1, oB2);
      bool bEqualB12b = object.Equals (oB2, oB1);
      bool bEqualB12c = oB1.Equals (oB2);
      bool bEqualB12d = oB2.Equals (oB1);
    // all false, as expected
      bool bEqualD13a = object.Equals (oD1, oD3);
      bool bEqualD13b = object.Equals (oD3, oD1);
      bool bEqualD13c = oD1.Equals (oD3);
      bool bEqualD13d = oD3.Equals (oD1);
      bool bEqualB13a = object.Equals (oB1, oB3);
      bool bEqualB13b = object.Equals (oB3, oB1);
      bool bEqualB13c = oB1.Equals (oB3);
      bool bEqualB13d = oB3.Equals (oB1);
    // all false, as expected
      bool bEqualD14a = object.Equals (oD1, oD4);
      bool bEqualD14b = object.Equals (oD4, oD1);
      bool bEqualD14c = oD1.Equals (oD4);
      bool bEqualD14d = oD4.Equals (oD1);
      bool bEqualB14a = object.Equals (oB1, oB4);
      bool bEqualB14b = object.Equals (oB4, oB1);
      bool bEqualB14c = oB1.Equals (oB4);
      bool bEqualB14d = oB4.Equals (oB1);
    }

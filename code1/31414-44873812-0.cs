    private class CBase
    {
    }
    private class CInherited : CBase
    {
    }
    private enum EnumTest
    {
      zero,
      one,
      two
    }
    private static void Main (string[] args)
    {
      //########## classes ##########
      // object creation, implicit cast to object
      object oBase = new CBase ();
      object oInherited = new CInherited ();
      CBase oBase2 = null;
      CInherited oInherited2 = null;
      bool bCanCast = false;
      // explicit cast using "()"
      oBase2 = (CBase)oBase;    // works
      oBase2 = (CBase)oInherited;    // works
      //oInherited2 = (CInherited)oBase;   System.InvalidCastException
      oInherited2 = (CInherited)oInherited;    // works
      // explicit cast using "as"
      oBase2 = oBase as CBase;
      oBase2 = oInherited as CBase;
      oInherited2 = oBase as CInherited;  // returns null, equals C++/CLI "dynamic_cast"
      oInherited2 = oInherited as CInherited;
      // testing with Type.IsAssignableFrom(), results (of course) equal the results of the cast operations
      bCanCast = typeof (CBase).IsAssignableFrom (oBase.GetType ());    // true
      bCanCast = typeof (CBase).IsAssignableFrom (oInherited.GetType ());    // true
      bCanCast = typeof (CInherited).IsAssignableFrom (oBase.GetType ());    // false
      bCanCast = typeof (CInherited).IsAssignableFrom (oInherited.GetType ());    // true
      //########## value types ##########
      int iValue = 2;
      double dValue = 1.1;
      EnumTest enValue = EnumTest.two;
      // implicit cast, explicit cast using "()"
      int iValue2 = iValue;   // no cast
      double dValue2 = iValue;  // implicit conversion
      EnumTest enValue2 = (EnumTest)iValue;  // conversion by explicit cast. underlying type of EnumTest is int, but explicit cast needed (error CS0266: Cannot implicitly convert type 'int' to 'test01.Program.EnumTest')
      iValue2 = (int)dValue;   // conversion by explicit cast. implicit cast not possible (error CS0266: Cannot implicitly convert type 'double' to 'int')
      dValue2 = dValue;
      enValue2 = (EnumTest)dValue;  // underlying type is int, so "1.1" beomces "1" and then "one"
      iValue2 = (int)enValue;
      dValue2 = (double)enValue;
      enValue2 = enValue;   // no cast
      // explicit cast using "as"
      // iValue2 = iValue as int;   error CS0077: The as operator must be used with a reference type or nullable type
    }

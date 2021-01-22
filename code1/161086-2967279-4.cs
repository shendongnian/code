    using System;
    using System.Reflection;
    public class Utilities {
      public static Object LoadCustomerType() {
        Assembly a = Assembly. Load(
          "xyzzy, Version=1. 2. 3.4, " +
          "Culture=neutral, PublicKeyToken=9a33f27632997fcc") ;
        return a.CreateInstance("AcmeCorp.LOB. Customer") ;
      }
    }

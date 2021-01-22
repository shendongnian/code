    using System;
    using System.Reflection;
    public class Utilities {
      public static Object LoadCustomerType() {
        Assembly a = Assembly. LoadFrom(
                        "file: //C:/usr/bin/xyzzy. dll") ;
        return a.CreateInstance("AcmeCorp.LOB. Customer") ;
      }
    }

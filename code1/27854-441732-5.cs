    using System;
    using System.Reflection;
    ........
    
    Type ty = typeof(System.Web.Security.SqlMembershipProvider);
    string fullname = ty.AssemblyQualifiedName;
    //"System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"

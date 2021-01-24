    // Decompiled with JetBrains decompiler
    // Type: dynamicType
    // Assembly: dynamicAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
    // MVID: 94346EDD-3BCD-4EB8-BA4E-C25343918535
    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class dynamicType
    {
      public static int dynamicMethod()
      {
        return ((IEnumerable<string>) new string[2]
        {
          "test",
          "test2"
        }).Where<string>(new Func<string, bool>(dynamicType.\u003CExpressionCompilerImplementationDetails\u003E\u007B1\u007Dlambda_method)).Select<string, int>(new Func<string, int>(dynamicType.\u003CExpressionCompilerImplementationDetails\u003E\u007B2\u007Dlambda_method)).FirstOrDefault<int>();
      }
      private static bool \u003CExpressionCompilerImplementationDetails\u003E\u007B1\u007Dlambda_method(string whereParam)
      {
        return whereParam.Length != 4;
      }
      private static int \u003CExpressionCompilerImplementationDetails\u003E\u007B2\u007Dlambda_method(string whereParam)
      {
        return whereParam.Length;
      }
    }

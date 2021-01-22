C:\Temp>type Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication1 {
  interface I<T> {
    T M(T p);
  }
  abstract class A<T> : I<T> {
    public abstract T M(T p);
  }
  abstract class B<T> : A<T>, I<int> {
    public override T M(T p) { return p; }
    public int M(int p) { return p * 2; }
  }
  class C : B<int> { }
  class Program {
    static void Main(string[] args) {
      Console.WriteLine(new C().M(11));
    }
  }
}
C:\Temp>csc Program.cs
Microsoft (R) Visual C# 2008 Compiler version 3.5.30729.1
for Microsoft (R) .NET Framework version 3.5
Copyright (C) Microsoft Corporation. All rights reserved.
C:\Temp>Program
Unhandled Exception: System.TypeLoadException: Could not load type 'ConsoleAppli
cation1.C' from assembly 'Program, Version=0.0.0.0, Culture=neutral, PublicKeyTo
ken=null'.
   at ConsoleApplication1.Program.Main(String[] args)
C:\Temp>peverify Program.exe
Microsoft (R) .NET Framework PE Verifier.  Version  3.5.30729.1
Copyright (c) Microsoft Corporation.  All rights reserved.
[token  0x02000005] Type load failed.
[IL]: Error: [C:\Temp\Program.exe : ConsoleApplication1.Program::Main][offset 0x
00000001] Unable to resolve token.
2 Error(s) Verifying Program.exe
C:\Temp>ver
Microsoft Windows XP [Version 5.1.2600]

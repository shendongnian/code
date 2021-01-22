    using System;
    public class oink {
        public static void Main() {
            A[] aOa = new A[10];
    
            if (aOa is IFoo[]) { Console.WriteLine("aOa is IFoo[]"); }
    
        }
        public interface IFoo {}
        public class A : IFoo {}
    }
    PS D:\> csc test.cs
    Microsoft (R) Visual C# 2008 Compiler version 3.5.30729.1
    for Microsoft (R) .NET Framework version 3.5
    Copyright (C) Microsoft Corporation. All rights reserved.
    
    PS D:\> D:\test.exe
    aOa is IFoo[]
    PS D:\>
 

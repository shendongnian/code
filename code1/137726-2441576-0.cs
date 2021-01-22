    C:\>copy con t.cs
    using System;
    using System.Linq;
    class Sample {
    public static void Main()
    {
    
        int[] ints = new int[] { -1, 12, 26, 41, 52, -1, -1 };
        int minInt = ints.Min();
        Console.WriteLine(minInt);
     }
    }
    ^Z
            1 file(s) copied.
    
    C:\>csc t.cs
    Microsoft (R) Visual C# 2008 Compiler version 3.5.30729.4926
    for Microsoft (R) .NET Framework version 3.5
    Copyright (C) Microsoft Corporation. All rights reserved.
    
    
    C:\>t
    -1
    
    C:\>

    var clone = new WhatTheHeck("Private-Set-Prop cloned!", "Get-Only-Prop cloned!", "Indirect-Field clonned!").CloneThroughJson();
    Console.WriteLine($"1. {clone.PrivateSet}");
    Console.WriteLine($"2. {clone.GetOnly}");
    Console.WriteLine($"3.1. {clone.Indirect}");
    Console.WriteLine($"3.2. {clone.RealIndirectFieldVaule}");

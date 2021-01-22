    static void Main( string[] args )
    {
        Console.WriteLine("First Call:");
        Test();
        Console.WriteLine("");
        Console.WriteLine("Second Call:");
        Test();
        Console.ReadLine();
    }
    public static void Test()
    {
        StaticLocalVariable<int> intTest1 = new StaticLocalVariable<int>(0);
        StaticLocalVariable<int> intTest2 = new StaticLocalVariable<int>(1);
        StaticLocalVariable<double> doubleTest1 = new StaticLocalVariable<double>(2.1);
        StaticLocalVariable<double> doubleTest2 = new StaticLocalVariable<double>();
        Console.WriteLine("Values upon entering Method: ");
        Console.WriteLine("    intTest1 Value: " + intTest1.Value);
        Console.WriteLine("    intTest2 Value: " + intTest2.Value);
        Console.WriteLine("    doubleTest1 Value: " + doubleTest1.Value);
        Console.WriteLine("    doubleTest2 Value: " + doubleTest2.Value);
        ++intTest1.Value;
        intTest2.Value *= 3;
        doubleTest1.Value += 3.14;
        doubleTest2.Value += 4.5;
        Console.WriteLine("After messing with values: ");
        Console.WriteLine("    intTest1 Value: " + intTest1.Value);
        Console.WriteLine("    intTest1 Value: " + intTest2.Value);
        Console.WriteLine("    doubleTest1 Value: " + doubleTest1.Value);
        Console.WriteLine("    doubleTest2 Value: " + doubleTest2.Value);            
    }
    // Output:
    // First Call:
    // Values upon entering Method:
    //     intTest1 Value: 0
    //     intTest2 Value: 1
    //     doubleTest1 Value: 2.1
    //     doubleTest2 Value: 0
    // After messing with values:
    //     intTest1 Value: 1
    //     intTest1 Value: 3
    //     doubleTest1 Value: 5.24
    //     doubleTest2 Value: 4.5
    // Second Call:
    // Values upon entering Method:
    //     intTest1 Value: 1
    //     intTest2 Value: 3
    //     doubleTest1 Value: 5.24
    //     doubleTest2 Value: 4.5
    // After messing with values:
    //     intTest1 Value: 2
    //     intTest1 Value: 9
    //     doubleTest1 Value: 8.38
    //     doubleTest2 Value: 9

    void MutateTest(Test instance)
    {
        instance.Mutate();
    }
    {
        Test test = new Test();
        test.i = 3;
        Console.WriteLine(test.i); // Writes 3
        test.Mutate(); // test.i is now 4
        Console.WriteLine(test.i); // Writes 4
        MutateTest(test); // MutateTest works on a copy.. "this" is only part of the copy itself
        Console.WriteLine(test.i); // Writes 4 still
    }

    ArrayList ints = new ArrayList();
    myInts.Add(1); // boxing
    myInts.Add(2); // boxing
    int myInt = (int)ints [0]; // unboxing
    Console.Write("Value is {0}", myInt); // boxing

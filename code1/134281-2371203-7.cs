    var dual = new Dual();
    // Call the ITest.Test() function by first assigning to an explicitly typed variable
    ITest test = dual;
    test.Test();
    // Call the ITest2.Test() function by using a type cast.
    ((ITest2)dual).Test();

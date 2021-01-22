    MyMethod(int a, int b) { /* ... */ }
    
    MyMethod(int[] c)
    {
       // check array length?
       MyMethod(c[0], c[1]);
    }
    AnotherMethod()
    {
       int[] someArray = new[] {1,2};
       MyMethod(someArray); // valid
       MyMethod(1,2);       // valid
    }

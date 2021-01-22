    static void Test() {
        try {
            Test2();                // Line 15
        }
        catch {
            throw;                  // Line 18
        }
    }
    static void Test2() {
        throw new Exception();      // Line 22
    }

    TestFactory.Test a = new TestFactory.Test(); // doesn't work because the class is private
    TestFactory.Test b = null; // also doesn't work because the class is private
    ITest c = null; // works, the interface is public
    ITest d = TestFactory.CreateTest(); // works, because the interface is public and CreateTest is declared to return the interface.
    

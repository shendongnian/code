    static void Main(string[] args) {
        var theBase = new Base();
        Console.WriteLine("Calling Base Class Non Virtual function");
        theBase.NonVirtualFuction();
        Console.WriteLine("\r\nCalling Base Class Virtual function directly");
        theBase.TheVirtualFunction();
        var theSub = new Sub();
        Console.WriteLine("\r\nCalling Non-Virtual Function (implemented in the base class) using sub-class reference");
        theSub.NonVirtualFuction();
        Console.WriteLine("\r\nCalling Sub Class Virtual function directly");
        theSub.TheVirtualFunction();
        Console.ReadLine();
    }

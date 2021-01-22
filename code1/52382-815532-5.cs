    public static void Main()
    {
        Test1();
        Test2();
    }
    
    private static void Test1()
    {
        using( MySerialPortAccessor port = new MySerialPortAccessor("COM1:"))
        {
            // do stuff
        }
    }
    
    private static void Test2()
    {
        using( MySerialPortAccessor port = new MySerialPortAccessor("COM1:"))
        {
            // do stuff
        }
    }

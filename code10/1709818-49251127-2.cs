    public static byte Foo { get; set; }
    public static void SetFooInDevice(System.IO.Ports.SerialPort sp, byte foo)
    {
        var txBuffer = new List<byte>();
        // Format message according to communication protocol
        txBuffer.Add(foo);
        sp.Write(txBuffer.ToArray(), 0, txBuffer.Count);
    }
    public static void Main()
    {
        List<Action> listActions = new List<Action>(); // here you create list of action you need to execute later
        var _rnd = new Random();
        var _serialPort = new System.IO.Ports.SerialPort("COM1", 9600);
        _serialPort.Open();
        for (int i = 0; i < 100; i++)
        {
            Foo = (byte)_rnd.Next(0, 255);
            var tmpFoo = Foo; // wee need to create local variable, this is important
            listActions.Add(() => SetFooInDevice(_serialPort, tmpFoo));
            System.Threading.Thread.Sleep(100);
        }
        foreach (var item in listActions)
        {
            item(); // here you can execute action you added to collection
        }
    }

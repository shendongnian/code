    public struct TestStruct
    {
     public int x;
     public string y;
    }
    public byte[] GetTestByte(TestStruct c)
    {
        var intGuy = BitConverter.GetBytes(c.x);
        var stringGuy = Encoding.UTF8.GetBytes(c.y);
        var both = stringGuy.Concat(intGuy).Concat(new byte[1]).ToArray();
        return both;
    }

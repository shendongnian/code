    var x = new NotAGoodIdea();
    x.TheBool = true;
    Console.WriteLine(x.TheByte);    // 1
    x.TheBool = false;
    Console.WriteLine(x.TheByte);    // 0
    // ...
    [StructLayout(LayoutKind.Explicit)]
    public struct NotAGoodIdea
    {
        [FieldOffset(0)]
        public bool TheBool;
        [FieldOffset(0)]
        public byte TheByte;
    }

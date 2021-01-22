    [DllImport("user32.dll")]static extern short VkKeyScan(char ch);
    
    static void Main(string[] args)
    {
        var helper = new Helper { Value = VkKeyScan('(') };
    
        byte virtualKeyCode = helper.Low;
        byte shiftState = helper.High;
    
        Console.WriteLine("{0}|{1}", virtualKeyCode, (Keys)virtualKeyCode);
        Console.WriteLine("SHIFT pressed: {0}", (shiftState & 1) != 0);
        Console.WriteLine("CTRL pressed: {0}", (shiftState & 2) != 0);
        Console.WriteLine("ALT pressed: {0}", (shiftState & 4) != 0);
        Console.WriteLine();
    
        Keys key = (Keys)virtualKeyCode;
    
        key |= (shiftState & 1) != 0 ? Keys.Shift : Keys.None;
        key |= (shiftState & 2) != 0 ? Keys.Control : Keys.None;
        key |= (shiftState & 4) != 0 ? Keys.Alt : Keys.None;
    
        Console.WriteLine(key);
        Console.WriteLine(new KeysConverter().ConvertToString(key));
    }
    
    [StructLayout(LayoutKind.Explicit)]
    struct Helper
    {
        [FieldOffset(0)]public short Value;
        [FieldOffset(0)]public byte Low;
        [FieldOffset(1)]public byte High;
    }

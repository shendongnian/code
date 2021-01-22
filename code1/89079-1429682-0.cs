    static void Main() 
    {
        int[] values = { 0, 0x111, 0xfffff, 0x8888, 0x22000022};
        foreach (int v in values)
        {
            Console.WriteLine("~0x{0:x8} = 0x{1:x8}", v, ~v);
        }
    }

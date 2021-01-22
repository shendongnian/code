    string[] array = { "A", "B", "C","D" };
    int count = 1 << array.Length; // 2^n
    
    for (int i = 0; i < count; i++)
    {
        string[] items = new string[array.Length];
        BitArray b = new BitArray(BitConverter.GetBytes(i));
        for (int bit = 0; bit < array.Length; bit++) {
            items[bit] = b[bit] ? array[bit] : "";
        }
        Console.WriteLine(String.Join("",items));
    }

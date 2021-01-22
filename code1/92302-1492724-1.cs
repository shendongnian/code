    static void Main(string[] args)
    {
        byte[] text = Encoding.ASCII.GetBytes("hellohello");
        byte[] output = Septets.Pack(text);
        for (int n = 0; n < output.Length; n++)
            Console.WriteLine(output[n].ToString("X"));
    }

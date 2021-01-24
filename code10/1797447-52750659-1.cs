    unsafe public static void Main(string[] args)
    {
       var bytes = new byte[2, 2];
       bytes[0, 0] = 0;
       bytes[0, 1] = 1;
       bytes[1, 0] = 2;
       bytes[1, 1] = 3;
    
       var length = bytes.GetLength(0) + bytes.GetLength(1);
       fixed (byte* p = bytes)
       {
          var span = new Span<byte>(p, length);
          var slice = span.Slice(1, 2);
          Console.WriteLine(slice[0]);
          Console.WriteLine(slice[1]);  
       }
    }

    byte[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
    var p1 = new ArraySegment<byte>(arr, 0, 5);
    var p2 = new ArraySegment<byte>(arr, 5, 5);
    Console.WriteLine("First array:");
    foreach (byte b in p1)
    {
    	Console.Write(b);
    }
    Console.Write("\n");
    Console.WriteLine("Second array:");
    foreach (byte b in p2)
    {
    	Console.Write(b);
    }

    object g1 = Guid.NewGuid();
    object g2 = new Guid(((Guid)g1).ToByteArray());
    Console.WriteLine("{0}\r\n{1}", g1, g2);
    Console.WriteLine("   Equals: {0}", g1.Equals(g2));
    Console.WriteLine("Object ==: {0}", g1 == g2);
    Console.WriteLine(" Value ==: {0}", (Guid)g1 == (Guid)g2);

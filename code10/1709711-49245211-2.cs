    String[] array1 = new String[] {"a", "b", "c", "d"};
    String[] array2 = new String[] {"y", "c", "h", "f"};
    String[] n1 = array1.Where(x => !array2.Contains(x)).ToArray();
    String[] n2 = array2.Where(x => !array1.Contains(x)).ToArray();
    Console.WriteLine("Array 1");
    foreach (String s in n1)
        Console.WriteLine(s);
    Console.WriteLine("\nArray 2");
    foreach (String s in n2)
        Console.WriteLine(s);
    Console.ReadLine();

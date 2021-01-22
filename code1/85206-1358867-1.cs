    // Definition of ranges
    int[] ranges = new int[] { 9, 19, 29 };
    // Lookup
    int position = Array.BinarySearch(ranges, 15);
    if (position < 0)
        position = ~position;
    Console.WriteLine("Position is {0}", position + 1);

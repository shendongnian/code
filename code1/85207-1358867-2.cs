    // Definition of ranges
    int[] ranges = new int[] { 9, 19, 29 };
    // Lookup
    int position = Array.BinarySearch(ranges, 15);
    if (position < 0)
        position = ~position;
    // Definition of range names
    string[] names = new string[] { "home", "street", "city", "far away" };
    Console.WriteLine("Position is: {0}", names[position]);

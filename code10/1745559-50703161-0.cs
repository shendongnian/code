    string[] list1 = 
    {
        "A", "B", "C", "D", "E", "F"
    };
    int[] list2 = 
    {
        50, 100, 14, 57, 48, 94
    };
    Array.Sort(list2, list1);
    Console.WriteLine(string.Join(", ", list1)); // C, E, A, D, F, B

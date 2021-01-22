    int[] original = { 1, 2, 3, 4, 5 };
    SubArray<int> copy = new SubArray<int>(original, 2, 2);
    Console.WriteLine(copy.Length); // shows: 2
    Console.WriteLine(copy[0]); // shows: 3
    foreach (int i in copy) Console.WriteLine(i); // shows 3 and 4

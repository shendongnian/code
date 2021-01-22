    int[] keys = { 1, 4, 3, 2, 5 };
    string[] items = { "abc", "def", "ghi", "jkl", "mno" };
    Array.Sort(keys, items);
    foreach (int key in keys) {
        Console.WriteLine(key); // 1, 2, 3, 4, 5
    }
    foreach (string item in items) {
        Console.WriteLine(item); // abc, jkl, ghi, def, mno
    }

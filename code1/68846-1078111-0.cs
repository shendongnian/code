    public static void UpdateAll<T>(this IList<T> list, Func<T, T> operation) {
        for (int i = 0; i < list.Count; i++) {
            list[i] = operation(list[i]);
        }
    }
    static void Main() {
        string[] arr = { "abc", "def", "ghi" };
        arr.UpdateAll(s => "new value");
        foreach (string s in arr) Console.WriteLine(s);
    }

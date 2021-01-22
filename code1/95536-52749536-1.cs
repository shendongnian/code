    public static int[] a = new int [] { 1, 2, 3, 4, 5 };
    public static int[] b = new int [] { 6, 7, 8 };
    public static int[] c = new int [] { 9, 10 };
    public static int[] z = new List<string>()
        .Concat(a)
        .Concat(b)
        .Concat(c)
        .ToArray();

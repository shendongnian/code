    public static double Invert(double value) {
        return 1.0 / value;
    }
    public static void Test() {
        int a = GetRandomsAsEnumerable(int.MaxValue).Select(Invert).Count();
        int b = GetRandomsAsArray(int.MaxValue).Select(Invert).Count();
    }

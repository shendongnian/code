    public static void PrintNext(i) {
        if (i <= 100) {
            Console.Write(i + " ");
            PrintNext(i + 1);
        }
    }
    public static void Main() {
        PrintNext(1);
    }

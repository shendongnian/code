    static void Main(string[] args) {
        String a = "Hello ";
        String b = " World! ";
        StringBuilder result = new StringBuilder(a.Length + b.Length * 20000);
        result.Append(a);
        for (int i=0; i<20000; i++) {
            result.Append(b);
        }
        Console.WriteLine(result.ToString());
    } 

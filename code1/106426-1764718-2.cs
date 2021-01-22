    static void Main(string[] args) {
        string s = "A" + "B";
        string t = "A" + "B";
        Console.WriteLine(Object.ReferenceEquals(s, t)); // prints true!
    }

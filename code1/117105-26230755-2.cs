    private Dictionary<string,Action> data = new Dictionary<string, Action> {
        {"foo", () => Console.WriteLine("Some logic here")},
        {"bar", () => Console.WriteLine("something else here")},
        {"raboof", () => Console.WriteLine("of course I need more than just WriteLine")},
    }
    public static void main(String[] args) {
        data["foo"]();
    }

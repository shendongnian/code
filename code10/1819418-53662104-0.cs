    public static void Main(string[] args) {
        // no passed argument here
        // we can read port here
        if (args.Length == 0) {
            // Console.ReadLine();
        }
        // we can parse args[0] as int (port)
        else {
            if (!int.TryParse(args[0], out int port)) {
                Console.WriteLine("Not a valid port!");
                return;
            }
            // Node creation
            Node node = new Node(port);
            // Do something
        }
    }

    static void Main(string[] args) {
        try {
            var tasks = new Task[3];
            tasks[0] = Server();
            tasks[1] = tasks[0].ContinueWith(c => {
                Console.WriteLine($"Server exited, cancelled={c.IsCanceled}");
            });
            tasks[2] = Clinet();
            Task.WhenAll(tasks).Wait();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
        Console.WriteLine("press [enter] to exit");
        Console.ReadLine();
    }

    static void Main(string[] args) {
        PrintCurrentVersion(); // no version
        using (var s1 = new VersionScope(1)) {
            PrintCurrentVersion(); // version 1
            s1.Complete();
            PrintCurrentVersion(); // no version, 1 is already completed
            using (var s2 = new VersionScope(2)) {
                using (var s3 = new VersionScope(3)) {
                    PrintCurrentVersion(); // version 3
                } // version 3 deleted
                PrintCurrentVersion(); // back to version 2
                s2.Complete();
            }
            PrintCurrentVersion(); // no version, all completed or deleted
        }
        Console.ReadKey();
    }
    private static void PrintCurrentVersion() {
        Console.WriteLine("Current version: " + VersionScope.CurrentVersion);
    }

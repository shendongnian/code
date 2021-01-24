    static void Main(string[] args) {
        Test();
        Console.ReadKey();
    }
    static async void Test() {
        PrintCurrentVersion(); // no version
        using (var s1 = new VersionScope(1, asyncFlow: true)) {
            await Task.Delay(100);
            PrintCurrentVersion(); // version 1
            await Task.Delay(100);
            s1.Complete();
            await Task.Delay(100);
            PrintCurrentVersion(); // no version, 1 is already completed
            using (var s2 = new VersionScope(2, asyncFlow: true)) {
                using (var s3 = new VersionScope(3, asyncFlow: true)) {
                    PrintCurrentVersion(); // version 3
                } // version 3 deleted
                await Task.Delay(100);
                PrintCurrentVersion(); // back to version 2
                s2.Complete();
            }
            await Task.Delay(100);
            PrintCurrentVersion(); // no version, all completed or deleted
        }
    }
    private static void PrintCurrentVersion() {
        Console.WriteLine("Current version: " + VersionScope.CurrentVersion);
    }

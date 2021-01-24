    static DateTime startTime;
    static void Main(string[] args) {
        DualTimer t = new DualTimer(100, 250);
        t.LeftTick += T_LeftTick;
        t.RightTick += T_RightTick;
        startTime = DateTime.Now;
        t.Start();
        Console.ReadKey();
        t.Stop();
    }
    private static void T_LeftTick(object sender, EventArgs e) {
        Console.WriteLine($"Right side tick. {DateTime.Now - startTime}");
    }
    private static void T_RightTick(object sender, EventArgs e) {
        Console.WriteLine($"Left side tick. {DateTime.Now - startTime}");
    }

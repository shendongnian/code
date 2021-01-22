class Program {
    static void Main(string[] args) {
        Action d = delegate {
            Console.WriteLine("From the delegate");
        };
        var e = new ManualResetEvent(false);
        d.BeginInvoke(r => {
            ((Action)r.AsyncState).EndInvoke(r);
            e.Set();
        }, d);
        e.WaitOne();
    }
}

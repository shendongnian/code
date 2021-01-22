    static class Program {
        [STAThread]
        static void Main() {
            var c = new Controller();
            c.CreateView(new Form1());
            c.Start();
        }
    }

    using System.Management;
    using System.Threading;
    public static class Program {
        [STAThread]
        public static void Main(string[] args) {
            Thread t = new Thread(new ThreadStart(Program.Shutdown));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            ...
        }
        public static void Shutdown() {
            // roomaroo's code
        }
    }

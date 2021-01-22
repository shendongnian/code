    // Args class.
    public class TickArgs : EventArgs {
        private DateTime TimeNow;
        public DateTime Time { get; set; }
    }
    
    // Producer class that generates events.
    public class Metronome {
        public event TickHandler Tick;
        public delegate void TickHandler(Metronome m, TickArgs e);
        public void Start() {
            while (true) {
                System.Threading.Thread.Sleep(3000);
                TickHandler ticker = Tick;
                if (ticker != null) {
                    TickArgs t = new TickArgs();
                    t.Time = DateTime.Now;
                    ticker(this, t);
                }
            }
        }
    }
    
    // Consumer class that listens for events.
    public class Listener {
        public void Subscribe(Metronome m) {
            m.Tick += (mm, e) => System.Console.WriteLine("HEARD IT AT {0}",e.Time)
        }
    }
    
    // Example.
    public class Test {
        static void Main() {
            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            m.Start();
        }
    }

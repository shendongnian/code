    namespace Events3
    {
        using System;
    
        // Args class.
        public sealed class TickArgs : EventArgs
        {
            private readonly DateTime TimeNow;
            public DateTime Time
            {
                get { return this.TimeNow; }
            }
            public TickArgs(DateTime TimeNow)
            {
                this.TimeNow = TimeNow;
            }
        }
    
        // Producer class that generates events.
        public sealed class Metronome
        {
            private event EventHandler<TickArgs> _Tick;
            public event EventHandler<TickArgs> Tick
            {
                add { this._Tick += value; }
                remove { this._Tick -= value; }
            }
            public void Start()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(3000);
                    EventHandler<TickArgs> tick = this._Tick;
                    if (tick != null)
                    {
                        tick(this, new TickArgs(DateTime.Now));
                    }
                }
            }
        }
    
        // Consumer class that listens for events.
        public sealed class Listener
        {
            public void Subscribe(Metronome m)
            {
                m.Tick += (sender, e) =>
                {
                    System.Console.WriteLine("HEARD IT AT {0}", e.Time);
                };
            }
        }
    
        // Example.
        public static class Test
        {
            static void Main()
            {
                Metronome m = new Metronome();
                Listener l = new Listener();
                l.Subscribe(m);
                m.Start();
            }
        }
    }

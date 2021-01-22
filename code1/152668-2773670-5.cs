      // Producer class that generates events.
        public class Metronome {
            // Add a dummy event handler and ensure that there's no unsafe thread issues 
            public event EventHandler<TickArgs> Tick = (m, e) => {};
            public void Start() {
                while (true) {
                    System.Threading.Thread.Sleep(3000);
                    // no need to check for null before calling
                    Tick(this, new TickArgs { Time = DateTime.Now; });
                }
            }
        }

      // Producer class that generates events.
        public class Metronome {
            // Add a dummy event handler and ensure that there's no unsafe thread safety issues 
            public event TickHandler Tick = (m, e) => {};
            public delegate void TickHandler(Metronome m, TickArgs e);
            public void Start() {
                while (true) {
                    System.Threading.Thread.Sleep(3000);
                        TickArgs t = new TickArgs {
                           Time = DateTime.Now;
                        }
                        ticker(this, t);
                   }
            }
        }

    //from http://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable
    using System;
    namespace wildert
    {
        public class TimeOfTickEventArgs : EventArgs //<- custom event args
        {
            private DateTime TimeNow;
            public DateTime Time
            {
                set { TimeNow = value; }
                get { return this.TimeNow; }
            }
        }
        public class Metronome
        {
            public delegate void TickEventHandler(object sender, TimeOfTickEventArgs e); //I put the delegate declaration before the events
            public event TickEventHandler Ticked; //Ticked(i.e. after something occurred), or possibly Ticking(i.e. before)
    		
            public void Start()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(3000);
                    if (Ticked != null){
                        TimeOfTickEventArgs tot = new TimeOfTickEventArgs();
                        tot.Time = DateTime.Now;
                        Ticked(this, tot); //<- publish the event
                    }
                }
            }
        }
    	public class Listener
    	{
    		public void Subscribe(Metronome m){
    			m.Ticked += new Metronome.TickEventHandler(HeardIt);  //<- subscribe to the event
    		}
    		private void HeardIt(object sender, TimeOfTickEventArgs e){ //<- this is the event handler (note signature 'object sender, xxx e')
    			System.Console.WriteLine("HEARD IT AT {0}",e.Time);
    		}
    	}
        class Test
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

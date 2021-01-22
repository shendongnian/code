    using System;
    using System.Timers;
    namespace App
    {
        class Program
        {
            static void TimerEvent(object s,ElpasedEventArgs arg)
            {
                //handle your stuff here
            }
            static void Main()
            {
                Timer t = new Timer(60000); //60 seconds * 1000 = 60.000
                t.Elapsed += new ElapsedEventHandler(TimerEvent);
                t.Start();
            }
        }
    }

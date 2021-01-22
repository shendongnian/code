    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    static class Program
    {
        static void Main()
        {
            Timer timer = new Timer();
            // timer.Interval = 4 minutes
            timer.Interval = (int)(TimeSpan.TicksPerMinute * 4 / TimeSpan.TicksPerMillisecond);
            timer.Tick += (sender, args) => { Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1); };
            timer.Start();
            Application.Run();
        }
    }

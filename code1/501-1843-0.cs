    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            static void Main()
            {
                Timer timer = new Timer();
                // timer.Interval = 4 minutes
                timer.Interval = (int)(TimeSpan.TicksPerMinute * 4 / TimeSpan.TicksPerMillisecond);
                timer.Tick += (sender, args) => { System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X + 1, System.Windows.Forms.Cursor.Position.Y + 1); };
                timer.Start();
                Application.Run();
            }
        }
    }

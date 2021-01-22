    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class Test
    {
        public static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Button start = new Button {
                Text = "Start",
                Location = new Point(10, 30)
            };
            Button stop = new Button {
                Text = "Stop",
                Location = new Point(10, 60)
            };
            
            ProgressBar bar = new ProgressBar {
                Style = ProgressBarStyle.Marquee,
                Location = new Point(10, 90),
                MarqueeAnimationSpeed = 20,
                Visible = false
            };
            Form form = new Form {
                Size = new Size(100, 200),
                Controls = { start, stop, bar }
            };
            start.Click += (s, a) => bar.Visible = true;
            stop.Click += (s, a) => bar.Visible = false;
            Application.Run(form);
        }
    }

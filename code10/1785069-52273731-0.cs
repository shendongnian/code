    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    namespace TestBlink
    {
        public partial class Form1 : Form
        {
            private Timer _timer;
            private ItemBlinker _itemBlinker = new ItemBlinker();
            public Form1()
            {
                InitializeComponent();
                // create the timer
                _timer = new Timer();
                _timer.Tick += Timer_Tick;
                _timer.Interval = 16;  //  +/- 60fps
                _timer.Enabled = true;
                // add two examples
                _itemBlinker.Add(label1, Color.FromArgb(30, 30, 30), Color.Red, 2000, true);
                _itemBlinker.Add(label2, Color.FromArgb(30, 30, 30), Color.Blue, 3000, true);
            }
            private void Timer_Tick(object sender, EventArgs e)
            {
                // update all blinkers
                _itemBlinker.Update();
            }
        }
        // this class will track al items.
        public class ItemBlinker
        {
            private List<BlinkItem> _items = new List<BlinkItem>();
            private Stopwatch _sw = Stopwatch.StartNew();
            public void Add(Control ctrl, Color c1, Color c2, short cycleTime_ms, bool bkClr)
            {
                _items.Add(new BlinkItem
                {
                    Ctrl = ctrl,
                    C1 = c1,
                    C2 = c2,
                    CycleTime_ms = cycleTime_ms,
                    BkClr = bkClr
                });
            }
            public void Remove(Control ctrl)
            {
                _items.RemoveAll(item => item.Ctrl == ctrl);
            }
            public void Update()
            {
                // get the elapsedMilliseconds
                var elapsedMilliseconds = _sw.ElapsedMilliseconds;
                // update each induvidual item
                foreach (var item in _items)
                    item.Update(elapsedMilliseconds);
            }
        }
        public class BlinkItem
        {
            public Control Ctrl { get; set; }
            public Color C1 { get; set; }
            public Color C2 { get; set; }
            public short CycleTime_ms { get; set; }
            public bool BkClr { get; set; }
            public void Update(long elapsedMilliseconds)
            {
                // your code which determines the color
                var halfCycle = CycleTime_ms / 2;
                var n = elapsedMilliseconds % CycleTime_ms;
                var per = (double)Math.Abs(n - halfCycle) / halfCycle;
                var red = (short)Math.Round((C2.R - C1.R) * per) + C1.R;
                var grn = (short)Math.Round((C2.G - C1.G) * per) + C1.G;
                var blw = (short)Math.Round((C2.B - C1.B) * per) + C1.B;
                var clr = Color.FromArgb(red, grn, blw);
                if (BkClr) Ctrl.BackColor = clr; else Ctrl.ForeColor = clr;
            }
        }
    }

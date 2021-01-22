    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    public class AnimatedScrollFlowLayoutPanel : FlowLayoutPanel
    {
        public new void ScrollControlIntoView(Control activeControl)
        {
            if (((this.IsDescendant(activeControl) && this.AutoScroll) &&
                (this.HScroll || this.VScroll)) && (((activeControl != null) &&
                (ClientRectangle.Width > 0)) && (ClientRectangle.Height > 0)))
            {
                Point point = this.ScrollToControl(activeControl);
                int x = DisplayRectangle.X, y = DisplayRectangle.Y;
                bool scrollUp = x < point.Y;
                bool scrollLeft = y < point.X;
                Timer timer = new Timer();
                EventHandler tickHandler = null;
                tickHandler = delegate {
                    int jumpInterval = ClientRectangle.Height / 10;
                    if (x != point.X || y != point.Y)
                    {
                        y = scrollUp ?
                            Math.Min(point.Y, y + jumpInterval) :
                            Math.Max(point.Y, y - jumpInterval);
                        x = scrollLeft ?
                            Math.Min(point.X, x + jumpInterval) :
                            Math.Max(point.X, x - jumpInterval);
                        this.SetScrollState(8, false);
                        this.SetDisplayRectLocation(x, y);
                        this.SyncScrollbars(true);
                    }
                    else
                    {
                        timer.Stop();
                        timer.Tick -= tickHandler;
                    }
                };
                timer.Tick += tickHandler;
                timer.Interval = 5;
                timer.Start();
            }
        }
        internal bool IsDescendant(Control descendant)
        {
            MethodInfo isDescendantMethod = typeof(Control).GetMethod(
                "IsDescendant", BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)isDescendantMethod.Invoke(this, new object[] { descendant });
        }
        private void SyncScrollbars(bool autoScroll)
        {
            MethodInfo syncScrollbarsMethod = typeof(ScrollableControl).GetMethod(
                "SyncScrollbars", BindingFlags.NonPublic | BindingFlags.Instance);
            syncScrollbarsMethod.Invoke(this, new object[] { autoScroll });
        }
    }

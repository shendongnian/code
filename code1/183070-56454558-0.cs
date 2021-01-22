    namespace MousLokasyonbulma
{
    class benimtooltip : ToolTip
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr h, int x, int y, int width, int height, bool redraw);
        public benimtooltip()
        {
            this.OwnerDraw = true;
            this.Draw += Benimtooltip_Draw;
        }
        private void Benimtooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
            var t = (ToolTip)sender;
            var h = t.GetType().GetProperty("Handle",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var handle = (IntPtr)h.GetValue(t);
            var location = new Point(650, 650);
            var ss= MoveWindow(handle, location.X, location.Y, e.Bounds.Width, e.Bounds.Height, false);
        }
    }

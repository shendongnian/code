    public class CustomForm : Form
    {
        /// <summary>
        /// How close your cursor must be to any of the sides/corners of the form to be able to resize
        /// </summary>
        public int GrabSize = 8;
        /// <summary>
        /// The shortcut keys for this form
        /// </summary>
        public Dictionary<Keys, Action> ShortcutKeys = new Dictionary<Keys, Action>();
        private bool Drag = false;
        private Point DragOrigin;
        private const int HT_LEFT = 10;
        private const int HT_RIGHT = 11;
        private const int HT_TOP = 12;
        private const int HT_BOTTOM = 15;
        private const int HT_TOPLEFT = 13;
        private const int HT_TOPRIGHT = 14;
        private const int HT_BOTTOMLEFT = 16;
        private const int HT_BOTTOMRIGHT = 17;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            // If hold left click on the form, then start the dragging operation
            if (e.Button == MouseButtons.Left)
            {
                // Only start dragging operation if cursor position is NOT within the resize regions
                if (e.X > GrabSize && e.X < Width - GrabSize && e.Y > GrabSize && e.Y < Height - GrabSize)
                {
                    DragOrigin = e.Location;
                    Drag = true;
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            // If let go of left click while dragging the form, then stop the dragging operation
            if (e.Button == MouseButtons.Left && Drag)
                Drag = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // Move the form location based on where the cursor has moved relative to where the cursor position was when we first started the dragging operation
            if (Drag)
                Location = new Point(Location.X + (e.Location.X - DragOrigin.X), Location.Y + (e.Location.Y - DragOrigin.Y));
        }
        /// <summary>
        /// Invokes any shortcut keys that have been added to this form
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            Action action;
            if(ShortcutKeys.TryGetValue(key, out action))
            {
                action.Invoke();
                return true;
            }
            return base.ProcessCmdKey(ref msg, key);
        }
        /// <summary>
        /// Handles resizing of a borderless control/winform
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if(FormBorderStyle == FormBorderStyle.None && m.Msg == 0x84)
            {
                Point CursorLocation = PointToClient(new Point(m.LParam.ToInt32()));
                if (CursorLocation.X <= GrabSize)
                {
                    if (CursorLocation.Y <= GrabSize) // TOP LEFT
                        m.Result = new IntPtr(HT_TOPLEFT);
                    else if (CursorLocation.Y >= ClientSize.Height - GrabSize) // BOTTOM LEFT
                        m.Result = new IntPtr(HT_BOTTOMLEFT);
                    else
                        m.Result = new IntPtr(HT_LEFT); // RESIZE LEFT
                }
                else if (CursorLocation.X >= ClientSize.Width - GrabSize)
                {
                    if (CursorLocation.Y <= GrabSize)
                        m.Result = new IntPtr(HT_TOPRIGHT); // RESIZE TOP RIGHT
                    else if (CursorLocation.Y >= ClientSize.Height - GrabSize)
                        m.Result = new IntPtr(HT_BOTTOMRIGHT); // RESIZE BOTTOM RIGHT
                    else
                        m.Result = new IntPtr(HT_RIGHT); // RESIZE RIGHT
                }
                else if (CursorLocation.Y <= GrabSize)
                    m.Result = new IntPtr(HT_TOP); // RESIZE TOP
                else if (CursorLocation.Y >= ClientSize.Height - GrabSize)
                    m.Result = new IntPtr(HT_BOTTOM); // RESIZE BOTTOM
            }
        }
    }

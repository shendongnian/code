    using System;
    using System.Windows.Forms;
    public class RTBNoZoom : RichTextBox
    {
        private const int MK_CONTROL = 0x0008;
        private const int WM_MOUSEWHEEL = 0x020A;
        public RTBNoZoom() { }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEWHEEL:
                    if (((int)m.WParam & MK_CONTROL) == MK_CONTROL)
                    {
                        m.WParam = IntPtr.Zero;
                        m.Result = IntPtr.Zero;
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }

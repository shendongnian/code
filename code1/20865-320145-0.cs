using System;
using System.Windows.Forms;
using System.ComponentModel;
namespace NoMinimizeTest
{
    public class MinimizeControlForm : Form
    {
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xf020;
        protected MinimizeControlForm()
        {
            AllowMinimize = true;
        }
        protected override void WndProc(ref Message m)
        {
            if (!AllowMinimize)
            {
                if (m.Msg == WM_SYSCOMMAND)
                {
                    if (m.WParam.ToInt32() == SC_MINIMIZE)
                    {
                        m.Result = IntPtr.Zero;
                        return;
                    }
                }
            }
            base.WndProc(ref m);
        }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Specifies whether to allow the window to minimize when the minimize button and command are enabled.")]
        [DefaultValue(true)]
        public bool AllowMinimize
        {
            get;
            set;
        }
    }
}

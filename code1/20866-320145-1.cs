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
            
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MINIMIZE && !CheckMinimizingAllowed())
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        private bool CheckMinimizingAllowed()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            OnMinimizing(args);
            return !args.Cancel;
        }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Allows a listener to prevent a window from being minimized.")]
        public event CancelEventHandler Minimizing;
        protected virtual void OnMinimizing(CancelEventArgs e)
        {
            if (Minimizing != null)
                Minimizing(this, e);
        }
    }
}

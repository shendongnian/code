    using System;
    using System.Windows.Forms;
    public static class ControlExtensionMethods
    {
        public static void MaybeInvoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }

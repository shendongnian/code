    using System.Collections.Generic;
    using System.Windows.Forms;
    public static class ControlExtensions
    {
        public static IEnumerable<Control> AllControls(this Control control)
        {
            foreach (Control c in control.Controls)
            {
                yield return c;
                foreach (Control child in c.Controls)
                    yield return child;
            }
        }
    }

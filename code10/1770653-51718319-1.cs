    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public static class ControlExtensions
    {
        public static Rectangle GetBoundsRelativeToForm(this Control c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));
            var form = c.FindForm();
            if (form == null)
                throw new InvalidOperationException("The control is not located on a form.");
            var parent = c.Parent;
            if (parent == null)
                throw new InvalidOperationException("The control does not have a parent.");
            var p = form.PointToClient(parent.PointToScreen(c.Location));
            return new Rectangle(p, c.Size);
        }
    }

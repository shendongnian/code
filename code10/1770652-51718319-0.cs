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
            var p1 = parent.PointToScreen(c.Location);
            var p2 = form.PointToScreen(new Point(0, 0));
            var p = new Point(p1.X - p2.X, p1.Y - p2.Y);
            return new Rectangle(p, c.Size);
        }
    }

    /// <summary>
    /// This class is a double-buffered ListBox for owner drawing.
    /// The double-buffering is accomplished by creating a custom,
    /// off-screen buffer during painting.
    /// </summary>
    public sealed class DoubleBufferedListBox : ListBox
    {
        #region Method Overrides
        /// <summary>
        /// Override OnTemplateListDrawItem to supply an off-screen buffer to event
        /// handlers.
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            Rectangle newBounds = new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height);
            using (BufferedGraphics bufferedGraphics = currentContext.Allocate(e.Graphics, newBounds))
            {
                DrawItemEventArgs newArgs = new DrawItemEventArgs(
                    bufferedGraphics.Graphics, e.Font, newBounds, e.Index, e.State, e.ForeColor, e.BackColor);
                // Supply the real OnTemplateListDrawItem with the off-screen graphics context
                base.OnDrawItem(newArgs);
                // Wrapper around BitBlt
                GDI.CopyGraphics(e.Graphics, e.Bounds, bufferedGraphics.Graphics, new Point(0, 0));
            }
        }
        #endregion
    }

    public static class MyExtensions
    {
        public static void Disable( this Control control, Control focusTarget )
        {
            control.TabStop = false;
            control.BackColor = Color.DimGray;
            control.Cursor = Cursors.Arrow;
            control.Enter += delegate { focusTarget.Focus(); };
        }
    }

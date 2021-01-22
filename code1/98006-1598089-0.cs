    // Declaration required for interop
    [DllImport(@"gdiplus.dll")]
    public static extern int GdipWindingModeOutline( HandleRef path, IntPtr matrix, float flatness );
    void someControl_Paint(object sender, PaintEventArgs e)
    {
        // Create a path and add some rectangles to it
        GraphicsPath path = new GraphicsPath();
        path.AddRectangles(rectangles.ToArray());
        // Create a handle that the unmanaged code requires. nativePath private unfortunately
        HandleRef handle = new HandleRef(path, (IntPtr)path.GetType().GetField("nativePath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(path));
        // Change path so it only contains the outline
        GdipWindingModeOutline(handle, IntPtr.Zero, 0.25F);
        using (Pen outlinePen = new Pen(Color.FromArgb(255, Color.Red), 2))
        {
            g.DrawPath(outlinePen, path);
        }
    }

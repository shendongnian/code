    private void button1_Click(object sender, EventArgs e)
    {
        Rectangle r = GetVisibleRectangle(this.panel1, button4);
        System.Diagnostics.Trace.WriteLine(r.ToString());
    }
    public static Rectangle GetVisibleRectangle(ScrollableControl sc, Control child)
    {
        Rectangle work = child.Bounds;
        work.Intersect(sc.ClientRectangle);
        return work;
    }

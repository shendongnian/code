    using System.Drawing;
    using System.Windows.Forms;
    
    public static Control FindControlAtPoint(Control container, Point pos)
    {
    	Control child;
    	foreach (Control c in container.Controls)
    	{
    		if (c.Visible && c.Bounds.Contains(pos))
    		{
    			// Point p1 = new Point(pos.X - c.Left, pos.Y - c.Top);
    			// Point p2 = c.PointToClient(pos);
    			// p1 is not equal to p2 on my project. I don't know why.
    			child = FindControlAtPoint(c, new Point(pos.X - c.Left, pos.Y - c.Top));
    			if (child == null) return c;
    			else return child;
    		}
    	}
    	return null;
    }
    
    public static Control FindControlAtCursor(Form form)
    {
    	Point pos = Cursor.Position;
    	if (form.Bounds.Contains(pos))
    		return FindControlAtPoint(form, form.PointToClient(Cursor.Position));
    	return null;
    }

    public static float MeasureString(string s, Font font)
    {
    	using (var g = Graphics.FromHwnd(IntPtr.Zero))
    	{
    		g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    
    		return g.MeasureString(s, font, int.MaxValue, StringFormat.GenericTypographic).Width;
    	}
    }

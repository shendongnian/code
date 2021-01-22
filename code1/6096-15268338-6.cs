	public static void DoubleBuffered(this Control control, bool enable)
	{
		var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		doubleBufferPropertyInfo.SetValue(control, enable, null);
	}

	static class NativeMethods {
		public const int LayeredWindow = 0x80000;//WS_EX_LAYERED
		#region Drawing
		[DllImport("User32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateLayeredWindow(IntPtr handle, IntPtr screenDc, ref Point windowLocation, ref Size windowSize, IntPtr imageDc, ref Point dcLocation, int colorKey, ref BlendFunction blendInfo, UlwType type);
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
		[DllImport("User32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("User32.dll")]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteDC(IntPtr hdc);
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject(IntPtr hObject);
		#endregion
	}
	struct BlendFunction {
		public byte BlendOp;
		public byte BlendFlags;
		public byte SourceConstantAlpha;
		public byte AlphaFormat;
	}
	enum UlwType : int {
		None = 0,
		ColorKey = 0x00000001,
		Alpha = 0x00000002,
		Opaque = 0x00000004
	}

    	private void ToolTip_Draw2(object sender, DrawToolTipEventArgs args)
		{
			var graphics = args.Graphics;
			var bounds = args.Bounds;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			var windowRect = GetWindowRect();
			graphics.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(bounds.Width, bounds.Height));
			using (var backBrush = new LinearGradientBrush(bounds, C.Color_LogitechGray2, this.BackColor, 90))
			{
				using (var path = GetRoundedRectangle(bounds, 10, 4, 4, 1))
				{
					args.Graphics.FillPath(backBrush, path);
					args.DrawText();
				}
			}
		}
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
		private Rectangle GetWindowRect()
		{
			RECT rect = new RECT();
			var window = typeof(ToolTip).GetField("window", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this) as NativeWindow;
			GetWindowRect(window.Handle, ref rect);
			return rect;
		}

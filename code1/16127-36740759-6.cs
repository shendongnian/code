	public static class HideAndShowWindowHelper
	{
		/// <summary>
		///		Intent: Ensure that small notification window is on top of other windows.
		/// </summary>
		/// <param name="window"></param>
		public static void ShiftWindowIntoForeground(Window window)
		{
			try
			{
				// Prevent the window from grabbing focus away from other windows the first time is created.
				window.ShowActivated = false;
                // Do not use .Show() and .Hide() - not compatible with Citrix!
				if (window.Visibility != Visibility.Visible)
				{
					window.Visibility = Visibility.Visible;
				}
				// We can't allow the window to be maximized, as there is no de-maximize button!
				if (window.WindowState == WindowState.Maximized)
				{
					window.WindowState = WindowState.Normal;
				}
				window.Topmost = true;
			}
			catch (Exception)
			{
				// Gulp. Avoids "Cannot set visibility while window is closing".
			}
		}
		/// <summary>
		///		Intent: Ensure that small notification window can be hidden by other windows.
		/// </summary>
		/// <param name="window"></param>
		public static void ShiftWindowIntoBackground(Window window)
		{
			try
			{
				// Prevent the window from grabbing focus away from other windows the first time is created.
				window.ShowActivated = false;
                // Do not use .Show() and .Hide() - not compatible with Citrix!
				if (window.Visibility != Visibility.Collapsed)
				{
					window.Visibility = Visibility.Collapsed;
				}
				// We can't allow the window to be maximized, as there is no de-maximize button!
				if (window.WindowState == WindowState.Maximized)
				{
					window.WindowState = WindowState.Normal;
				}
				window.Topmost = false;
			}
			catch (Exception)
			{
				// Gulp. Avoids "Cannot set visibility while window is closing".
			}
		}
	}

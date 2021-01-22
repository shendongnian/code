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
				if (window.Visibility != Visibility.Visible)
				{
					window.Visibility = Visibility.Visible;
				}
				window.Topmost = true;
			}
			catch (Exception)
			{
				// Avoids small possibility of "Cannot set visibility while window is closing". 
                // Minimize this chance by running on the dispatcher thread.
			}
		}
		/// <summary>
		///		Intent: Ensure that small notification window is NOT on top of other windows.
		/// </summary>
		/// <param name="window"></param>
		public static void ShiftWindowIntoBackground(Window window)
		{
			try
			{
				if (window.Visibility != Visibility.Collapsed)
				{
					window.Visibility = Visibility.Collapsed;
				}
				window.Topmost = false;
			}
			catch (Exception)
			{
				// Avoids "Cannot set visibility while window is closing".
                // Minimize this chance by running on the dispatcher thread.
			}
		}
	}

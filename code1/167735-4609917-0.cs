    /// <summary>
		/// Call to toggle between the current cursor and the wait cursor
		/// </summary>
		/// <param name="control">The calling control.</param>
		/// <param name="toggleWaitCursorOn">True for wait cursor, false for default.</param>
		public static void UseWaitCursor(this Control control, bool toggleWaitCursorOn)
		{
			...
			control.UseWaitCursor = toggleWaitCursorOn;
			// Because of a weird quirk in .NET, just setting UseWaitCursor to false does not work
			// until the cursor's position changes. The following line of code fakes that and 
			// effectively forces the cursor to switch back  from the wait cursor to default.
			if (!toggleWaitCursorOn)
				Cursor.Position = Cursor.Position;
		}

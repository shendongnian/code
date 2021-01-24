	public static class ControlExtensions
	{
		public static void UpdateOnUIThread<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
		{
			if (control.InvokeRequired)
				control.Invoke(action, new object[] { control });
			else
				action(control);
		}
	}

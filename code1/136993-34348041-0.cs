	internal static class ControlExtension
	{
		public static bool IsInDesignMode(this Control control)
		{
			while (control != null)
			{
				if (control.Site != null && control.Site.DesignMode)
					return true;
				control = control.Parent;
			}
			return false;
		}
	}

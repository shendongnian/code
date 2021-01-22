	public static class ExtensionMethods
	{
		public static IEnumerable<Control> FindControls(this Control root)
		{
			foreach (Control ctrl in root.Controls)
			{
				yield return ctrl;
				foreach (Control desc in ctrl.FindControls())
					yield return desc;
			}
		}
	}

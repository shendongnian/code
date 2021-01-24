    public static IEnumerable<T> RecursiveControlsOfType<T>(this Control rootControl) where T : Control
	{
		foreach (Control child in rootControl.Controls)
		{
			if (child is T targetControl)
				yield return targetControl;
			foreach (T targetControlChild in child.RecursiveControlsOfType<T>())
				yield return targetControlChild;
		}
	}

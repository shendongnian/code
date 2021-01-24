	public static IEnumerable<Control> AllControls(Control parent)
	{
		if (parent == null)
			throw new ArgumentNullException();
			
		return implementation();
		IEnumerable<Control> implementation()
		{
			foreach (Control control in parent.Controls)
			{
				foreach (Control child in AllControls(control))
				{
					yield return child;
				}
				yield return control;
			}
		}
	}

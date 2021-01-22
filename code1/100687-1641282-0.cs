	/// <summary>
	/// Finds a Control recursively. Note finds the first match and exists
	/// </summary>
	/// <param name="container">The container to search for the control passed. Remember
	/// all controls (Panel, GroupBox, Form, etc are all containsers for controls
	/// </param>
	/// <param name="name">Name of the control to look for</param>
	public Control FindControlRecursive(Control container, string name)
	{
		if (container == name) return container;
		foreach (Control ctrl in container.Controls)
		{
			Control foundCtrl = FindControlRecursive(ctrl, name);
			
			if (foundCtrl != null) return foundCtrl;
		}
		
		return null;
	}

	public List<Control> FindControls(Control root, Type type)
	{
		var controls = new List<Control>();
		foreach (Control ctrl in root.Controls)
		{
			if (ctrl.GetType() == type)
				controls.Add(ctrl);
			if (ctrl.Controls.Count > 0)
				controls.AddRange(FindControls(ctrl, type));
		}
		return controls;
	}

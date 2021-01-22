	protected List<Control> FindControls(Control root, Type type, List<Control> ctrlCol = null)
	{
		List<Control> controls;
		if (ctrlCol == null)
			controls = new List<Control>();
		else
			controls = ctrlCol;
		foreach (Control ctrl in root.Controls)
		{
			if (ctrl.GetType() == type)
				controls.Add(ctrl);
			if (ctrl.Controls.Count > 0)
				FindControls(ctrl, type, controls);
		}
		return controls;
	}

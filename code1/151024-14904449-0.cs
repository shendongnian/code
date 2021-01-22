	Stack<Control> controlStack = new Stack<Control>();
	foreach (Control c in this.Controls)
	{
		controlStack.Push(c);
	}
	Control ctl;
	while (controlStack.Count > 0 && (ctl = controlStack.Pop()) != null)
	{
		if (ctl is RadioButton)
		{
			(ctl as RadioButton).CheckedChanged += new EventHandler(rb_CheckedChanged);
		}
		foreach (Control child in ctl.Controls)
		{
			controlStack.Push(child);
		}
	}

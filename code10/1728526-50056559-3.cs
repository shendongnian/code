	List<IControl> controls = new List<IControl>();
	controls.Add(new Button());
	controls.Add(new Player());
	controls.Add(new Image());
	foreach (IControl control in controls)
	{
		control.Draw();
	}

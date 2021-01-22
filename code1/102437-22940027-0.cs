    for (Control control in GetAllControls(this.Controls))
    {
        control.Enabled = false;
    }
    public List<Control> GetAllControls(Control.ControlCollection containerControls, params Control[] excludeControlList)
	{
			List<Control> controlList = new List<Control>();
			Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
			queue.Enqueue(containerControls);
			while (queue.Count > 0)
			{
				Control.ControlCollection controls = queue.Dequeue();
				if (controls == null || controls.Count == 0)
					continue;
				foreach (Control control in controls)
				{
					if (excludeControlList != null)
					{
						if (excludeControlList.SingleOrDefault(expControl => (control == expControl)) != null)
							continue;
					}
					controlList.Add(control);
					queue.Enqueue(control.Controls);
				}
			}
			return controlList;
		}

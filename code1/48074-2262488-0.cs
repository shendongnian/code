	private void TabControlMainMouseDown(object sender, MouseEventArgs e)
	{
		var tabControl = sender as TabControl;
		TabPage tabPageCurrent = null;
		if (e.Button == MouseButtons.Middle)
		{
			for (var i = 0; i < tabControl.TabCount; i++)
			{
				if (!tabControl.GetTabRect(i).Contains(e.Location))
					continue;
				tabPageCurrent = tabControl.TabPages[i];
				break;
			}
			if (tabPageCurrent != null)
				tabControl.TabPages.Remove(tabPageCurrent);
		}
	}

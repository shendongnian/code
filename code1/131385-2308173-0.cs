		private void lstModules_MouseDown(object sender , MouseEventArgs e)
		{
			hitTest = lstModules.HitTest(e.Location);
			switch (e.Button)
			{
				case MouseButtons.Right:
					if (hitTest != null && hitTest.Item != null)
					{
						// right clicking an item in the listview
						selectedModule = hitTest.Item.Name;
						lstModules.ContextMenuStrip = mnuContext_OptionsA;
					}
					else
					{ 
						// right clicking in white area of listview
						lstModules.ContextMenuStrip = mnuContext_OptionsB; 
					}
					break;
			}
		}

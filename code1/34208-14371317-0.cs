		private void MyForm_MdiChildActivate(object sender, EventArgs e)
		{
			this.panel_Tools.Visible = false;
			if (this.MdiChildren.Count() == 1)
			{
				this.timer_WindowsCounter.Start();
			}
			else
			{
				this.timer_WindowsCounter.Stop();
			}
		}
		private void timer_WindowsCounter_Tick(object sender, EventArgs e)
		{
			if (this.MdiChildren.Count() == 0)
			{
				this.panel_Tools.Visible = true;
				this.timer_WindowsCounter.Stop();
			}
		}

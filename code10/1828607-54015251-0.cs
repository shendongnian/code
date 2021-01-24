	private void btnSearch_Click(object sender, EventArgs e)
	{
	    using (frmCombinedSearch frm = new frmCombinedSearch())
		{
			try
			{
				// Custom code which just shows the form in the current tab
				frm.ShowInTab(this.ParentTabPage);
			}
			catch (Exception ex)
			{
				this.ShowException(ex);
			}
		}
	}
	

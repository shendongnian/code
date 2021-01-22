	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bIniModified) 
		{
			pnlExitMode.Visible = true; pnlExitMode.BringToFront();
			e.Cancel = true;
		}
	}
	private void btnYes_Click(object sender, EventArgs e)
	{
		SaveToIni();
		pnlExitMode.Visible = false; bIniModified = false;
		Application.Exit();
	}
	private void btnNo_Click(object sender, EventArgs e)
	{
		pnlExitMode.Visible = false; bIniModified = false;
		Application.Exit();
	}

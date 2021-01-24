	private void button1_Click(object sender, EventArgs e)
	{
		new Thread(() =>
		{
			if (URLLMemoRichTxt.InvokeRequired)
			{
				URLLMemoRichTxt.Invoke((MethodInvoker)delegate ()
				{
					// .. do some "work" in here ...
					Thread.Sleep(9000);
				});
			}
		}).Start();
	}

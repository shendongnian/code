    public void ShowOptionsForm()
	{
		using (var form = new OptionsForm())
		{
			if (form.ShowDialog() == DialogResult.OK)
			{
				var option1Value = form.Option1;
				var option2Value = form.Option2;
				// use option values...
			}
		}
	}

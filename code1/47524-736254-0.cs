    public void CheckBox1CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked) {
			checkBox1.Text = "Enabled";
		}
		else {
			checkBox1.Text = "Disabled";
		}
	}

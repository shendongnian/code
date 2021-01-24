    protected override void OnKeyPress(KeyPressEventArgs e)
	{
		//combine the current Text and the pressed KeyChar;
		string combText = this.Text + e.KeyChar;
		// Ignore all non-control and non-numeric key presses.
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
		{
			e.Handled = true;
			MessageBox.Show("Only Numbers are allowed");
		}
		else if (int.TryParse(combText, out int res) && res > 50 && combText.Length <= 2)
		{
			MessageBox.Show("greater than 50");
		}
		base.OnKeyPress(e);
	}

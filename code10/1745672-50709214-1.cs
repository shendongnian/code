    void txtRed_Enter(object sender, EventArgs e)
	{
		txtRed.BackColor = Color.Yellow;
		txtYellow.BackColor = Color.Gray;
        txtGreen.BackColor = Color.Gray;
	}
	void txtYellow_Enter(object sender, EventArgs e)
	{
		txtRed.BackColor = Color.Gray;
		txtYellow.BackColor = Color.Yellow;
        txtGreen.BackColor = Color.Gray;
	}
    void txtGreen_Enter(object sender, EventArgs e)
	{
		txtRed.BackColor = Color.Gray;
		txtYellow.BackColor = Color.Gray;
        txtGreen.BackColor = Color.Yellow;
	}

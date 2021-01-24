    protected void btnShow_Click(object sender, EventArgs e)
	{
		for (int i = 1; i <= 5; i++)
		{
			var name = (TextBox)this.FindControl("txtName" + i);
			litNames.Text += name.Text;
		}
	}

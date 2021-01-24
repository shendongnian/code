	private void LoginBtn_Click(object sender, EventArgs e)
	{
		userName = UserNameTxt.Text;
		passWord = PasswordTxt.Text;
		
		if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
		{
			UserNameTxt.BackColor = Color.LightYellow;
			PasswordTxt.BackColor = Color.LightYellow;
			UserNameTxt.ForeColor = Color.Red;
			PasswordTxt.ForeColor = Color.Red;
			MessageBox.Show("Du måste ange ett användarnamn och Lösenord!");
			return;
		}
		IsServerConnected();
		if (testingConnection)
		{
			if(CheckBoxSave.Checked)
			{
				Properties.Settings.Default.UserName = UserNameTxt.Text;
				Properties.Settings.Default.UserPass = PasswordTxt.Text;
				Properties.Settings.Default.Save();
			}
			DialogResult = DialogResult.OK;
		} 
		else 
		{
			UserNameTxt.BackColor = Color.LightYellow;
			PasswordTxt.BackColor = Color.LightYellow;
			UserNameTxt.ForeColor = Color.Red;
			PasswordTxt.ForeColor = Color.Red;
			MessageBox.Show("Fel användarnamn eller lösenord");
		}
	}

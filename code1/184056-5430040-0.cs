        private void FRIIB_Load(object sender, EventArgs e)
        {
			try
			{
				QueryBuilder.insql = Crypto.DecryptStringAES(Model.DecryptRegisteryValue("inSQL"), "inSQL");
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			} // getting connection string
			if (!(new Func<bool>(() =>
					{
						Func<bool> l = null; l = () =>
						{
							using (LoginForm loginDialog = new LoginForm())
							{
								loginDialog.ShowDialog();
								loginDialog.Focus();
								if (loginDialog.IsExit) return false;
								else
									if (loginDialog.IsAuthorized) return true;
									else return l();
							}
						}; return l();
					}
				  )()
				)) Close(); 
			else w8( () => LoadData() );
        }

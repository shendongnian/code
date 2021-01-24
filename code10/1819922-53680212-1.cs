    protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == (Keys.Control | Keys.I))
			{
				MessageBox.Show("Ctrl+I");
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

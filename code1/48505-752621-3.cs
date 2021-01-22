		public void ChangeConfig()
		{
			using (ConfigForm MyForm = new ConfigForm())
			{
				DialogResult ConfigResult = MyForm.ShowDialog();
				if (ConfigResult == DialogResult.OK)
					SaveConfig();
			}
			ConfigForm MyForm = new ConfigForm();
			DialogResult ConfigResult = MyForm.ShowDialog();
			MyForm.Dispose();
			if (ConfigResult == DialogResult.OK)
				SaveConfig();
		}

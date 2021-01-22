	// Get list box contents
	var sb = new StringBuilder();
	foreach (var item in lstBox.Items)
	{
		// i am using the .ToString here, you may do more
		sb.AppendLine(item);
	}
	string data = sb.ToString();
		
	// Append Info
	data = data + ????....
	
	// Write File
	void Save(string data)
	{
		using(SaveFileDialog saveFileDialog = new SaveFileDialog())
		{
			// optional
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
		
			//saveFileDialog.Filter = ???;
		
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(saveFileDialog.Filename);
				MessageBox.Show("ok", "all good etc");
			}
			else
			{
			// not good......
			}
		}
	}

    void refresh() //gets called by button
	{
		if(!String.IsNullOrEmpty(objDialog.SelectedPath))
		{
			listBox1.Items.Clear();
			//will cause exception
			var files = System.IO.Directory.GetFiles(objDialog.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);
			foreach (string file in files)
			{
			   xxx
			}
			xxx
			xxx
		}
	}

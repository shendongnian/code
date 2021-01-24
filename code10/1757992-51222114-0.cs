    private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
	{
		const int specifiedLine = 32;
	    string line;
		
	    if (openFileDialog1.ShowDialog() == DialogResult.OK)
	    {
			line = GetSpecifiedLine(openFileDialog1.FileName, specifiedLine);
	    }
	
	}
	
	private string GetSpecifiedLine(string fileName, int specifiedLine)
	{
		int lineCount = 0;
			
	    using (StreamReader sr = new StreamReader(fileName))
		{
			lineCount++;
			var line = sr.ReadLine();
			while (line != null)
			{
				if (lineCount == specifiedLine)
				{
					return line;
				}
				line = sr.ReadLine();
			}
			
			return null;
		}
	}

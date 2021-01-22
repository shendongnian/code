        int lineNumber = 1;
		int userCount = 1234;
		string line = null;
		
		using(TextReader tr = File.OpenText("OriginalFile"))
		using(TextWriter tw = File.CreateText("ResultFile"))
		{
			
			while((line = tr.ReadLine()) != null)
			{
				if(lineNumber == 1)
				{
					line = line.Replace("{UserCount}", userCount.ToString());
				}
				
				tw.WriteLine(line);
				lineNumber++;
			}
			
		}

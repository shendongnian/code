    public void Split(string inputfile, string outputfilesformat)
    {
        int i = 0;
        System.IO.StreamWriter outfile = null;
        string line;
        try
        {
		  var firstLine = string.Empty;
	      using (var infile = new System.IO.StreamReader(inputfile))
          {
				
                while (!infile.EndOfStream)
                {
                    line = infile.ReadLine();
					if(string.IsNullOrEmpty(firstLine))
					firstLine = line;
                    if (line.Contains("/*"))  
                    {
                        if (outfile != null)
                        {
                            outfile.Dispose();
                            outfile = null;
                        }
                    }
                    if (outfile == null)
                    {
                        outfile = new System.IO.StreamWriter(
                            $"{firstLine}.txt",
                            false,
                            infile.CurrentEncoding);
                       firstLine = string.Empty;
                    }
                    outfile.WriteLine(line);
                }
            }
        }
        finally
        {
            if (outfile != null)
                outfile.Dispose();
        }
    }
